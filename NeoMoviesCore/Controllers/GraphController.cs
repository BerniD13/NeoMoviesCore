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

namespace NeoMoviesCore.Controllers
{
    [Route("graph")]
    public class GraphController : Controller
    {
        private static IGraphClient GraphClient { get; set; }
        public GraphController(IOptions<DatabaseSettings> dbSettings)
        {
            var url = dbSettings.Value.GraphDBUrl;
            var user = dbSettings.Value.GraphDBUser;
            var password = dbSettings.Value.GraphDBPassword;
            /*
			var url = "http://database:7474/db/data";
			var user = "neo4j"; 
            var password = "movies";
			*/
            var client = new GraphClient(new Uri(url), user, password);
            client.Connect();
            GraphClient = client;
        }
        [HttpGet]
        public IActionResult Index()

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
            List<string> data = new List<string>();
            foreach (var json in result)
            {
                data.Add(JsonConvert.SerializeObject(json));
            }
            Console.WriteLine(data[0]);
            System.IO.File.WriteAllLines(@"graph.json", data);

            return Ok();

        }
    }
}