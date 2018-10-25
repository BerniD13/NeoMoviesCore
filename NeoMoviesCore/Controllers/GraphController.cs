using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Neo4jClient;
using Neo4jClient.Cypher;
using NeoMoviesCore.Common.Model;
using NeoMoviesCore.Common.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NeoMoviesCore.Controllers
{
    [Route("graph")]
    public class GraphController : Controller
    {
        private static IGraphClient GraphClient { get; set; }
        public GraphController(IOptions<DatabaseSettings> dbSettings)
        {
            // var url = dbSettings.Value.GraphDBUrl;
            // var user = dbSettings.Value.GraphDBUser;
            // var password = dbSettings.Value.GraphDBPassword;

			var url = "http://localhost:7474/db/data";
			var user = "neo4j";
            var password = "movies";

            var client = new GraphClient(new Uri(url), user, password);
            client.Connect();
            GraphClient = client;
        }

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[Route("movie")]
		public IActionResult Get()
		{
            var query = GraphClient.Cypher
                .Match("(m:Movie)<-[:ACTED_IN]-(a:Person)")
                .Return((m, a) => new {
                    movie = m.As<Movie>().title,
                    cast = Return.As<string>("collect(a.name)")
                });

            //You can see the cypher query here when debugging
            var result = query.Results.ToList();
            // Console.WriteLine(data[0]);
            var nodes = new List<ElementResult>();
            var edges = new List<EdgeResult>();
            int i = 0, target, j=0; // j is the id of the edges
            foreach (var item in result)
            {
                var data = new Data { id = i.ToString(), name = item.movie, classes = "movie" };
                nodes.Add(new ElementResult { data = data });
                target = i; 
                i++;
                if (!string.IsNullOrEmpty(item.cast))
                {
                    var casts = JsonConvert.DeserializeObject<JArray>(item.cast);
                    foreach (var cast in casts)
                    {
                        var source = nodes.FindIndex(c => c.data.name == cast.Value<string>());
                        if (source == -1)
                        {
                            data = new Data { id = i.ToString(), name = cast.Value<string>(), classes = "actor" };
                            nodes.Add(new ElementResult { data = data });
                            source = i;
                            i += 1;
                        }
                        var rel = new Link { id = "e"+j.ToString(), source = source.ToString(), target = target.ToString() };
                        edges.Add(new EdgeResult{ data = rel});
                        j += 1;
                    }
                }
            }

            List<Object> elements = (from x in nodes select (Object)x).ToList();
            elements.AddRange((from x in edges select (Object)x).ToList());
            List<string> text = new List<string>();
            text.Add(JsonConvert.SerializeObject(new { elements = elements }));
            System.IO.File.WriteAllLines(@"graph.json", text);
            //List<string> data = new List<string>();
            //foreach (var json in result)
            //{
            //    data.Add(JsonConvert.SerializeObject(json));
            //}
            //Console.WriteLine(data[0]);
            //System.IO.File.WriteAllLines(@"graph.json", data);
            return Ok(new { elements });
        }
    }

    public class Data
    {
        public string name { get; set; }
        public string id { get; set; }
        public string classes { get; set; }
    }

    public class Link
    {
        public string source { get; set; }
        public string target { get; set; }
        public string id { get; set; }
    }

    public class EdgeResult
    {
        public Link data { get; set; }
    }

    public class ElementResult
    {
        public Data data { get; set; }
    }
}

