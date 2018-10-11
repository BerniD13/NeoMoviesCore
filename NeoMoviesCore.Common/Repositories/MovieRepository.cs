﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using NeoMoviesCore.Common.Model;
using Neo4jClient;

namespace NeoMoviesCore.Common.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static IGraphClient GraphClient { get; set; }

        public MovieRepository()
        {
            var url = @"http://database:7474/db/data"; //ConfigurationManager.AppSettings["GraphDBUrl"];
            var user = "neo4j"; //ConfigurationManager.AppSettings["GraphDBUser"];
            var password = "movies"; //ConfigurationManager.AppSettings["GraphDBPassword"];
            var client = new GraphClient(new Uri(url), user, password);
            client.Connect();     
            GraphClient = client;
        }

        public IEnumerable<Movie> GetMoviesByActor(string actor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> SearchMoviesByString(string s)
        {
            var data = GraphClient.Cypher
               .Match("(m:Movie)<-[:ACTED_IN]-(p:Person)")
               .Where("m.title =~ {query} OR p.name =~ {query}")
               .WithParam("query", "(?i).*" + s + ".*")
               .Return<Movie>("distinct m")
               .Results.ToList();

            return data;
        }
    }
}
