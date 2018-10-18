﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using NeoMoviesCore.Common.Model;
using Neo4jClient;
using Microsoft.Extensions.Options;

namespace NeoMoviesCore.Common.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static IGraphClient GraphClient { get; set; }

        public MovieRepository(IOptions<DatabaseSettings> dbSettings)
        {
            var url = dbSettings.Value.GraphDBUrl; 
            var user = dbSettings.Value.GraphDBUser; 
            var password = dbSettings.Value.GraphDBPassword;
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

        //+++
        public IEnumerable<Movie> AddMovie(IEnumerable<Movie> movie)
        {
            throw new NotImplementedException();
        }
        // SearchController
        public IEnumerable<Movie> SearchMoviesById(int id)
        {
            var data = GraphClient.Cypher
               .Match("(m:Movie)")
               .Where("ID(m) = {query}")
               .WithParam("query", id)
               .Return<Movie>("m")
               .Results.ToList();

            return data;
        }

        //CRUD operations
        public void CreateMovie(Movie m) // Currently does not show up at ~/api/search since no actors in it
        {
            GraphClient.Cypher
                .Create("(:Movie {m})")
                .WithParam("m", m)
                .ExecuteWithoutResults();
        }

        public Movie ReadMovie(int id)
        {
            throw new NotImplementedException();
        }


        public void UpdateMovie(int id, Movie m)
        {
            GraphClient.Cypher
                .Match("(cur_m:Movie)")
                .Where("ID(cur_m) = {query}")
                .WithParam("query", id)
                .Set("cur_m = {m}")
                .ExecuteWithoutResults();
        }

        public void DeleteMovie(int id)
        {
            GraphClient.Cypher
                .Match("(m:Movie)")
                .Where("ID(m) = {query}")
                .WithParam("query", id)
                .Delete("m")
                .ExecuteWithoutResults();
            //throw new NotImplementedException();
        }

    }
}
