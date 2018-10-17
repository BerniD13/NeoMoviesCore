using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeoMoviesCore.Common.Model;
using NeoMoviesCore.Common.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NeoMoviesCore.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {
        private readonly IMovieRepository _repo;

        public SearchController(IMovieRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _repo.SearchMoviesByString("John");
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<Movie> Get(int id)
        {
			return _repo.SearchMoviesById(id);
		}

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
