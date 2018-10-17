using System;
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
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repo;

        public MovieController(IMovieRepository repo)
        {
            _repo = repo;
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/movies/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/movies
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            _repo.CreateMovie(movie);
        }


        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie movie)
        {
            _repo.UpdateMovie(id, movie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteMovie(id);
        }
    }
}

