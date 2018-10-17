﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NeoMoviesCore.Common.Model;
using NeoMoviesCore.Common.Repositories;

namespace NeoMoviesCore.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _repo;

        public MovieController(IMovieRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // AddMovie: api/Movies
        [HttpPost, Route("api/movies")]
        public void AddMovie([FromBody] IEnumerable<Movie> movie)
        {
            // ???
            _repo.AddMovie(movie);
        }


        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
