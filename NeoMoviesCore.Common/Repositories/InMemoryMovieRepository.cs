using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeoMoviesCore.Common.Model;

namespace NeoMoviesCore.Common.Repositories
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        private List<Movie> movies;

        public InMemoryMovieRepository()
        {
            movies = new List<Movie>();
        }
        public IEnumerable<Movie> SearchMoviesByString(string s)
        {
            var queryMovies = from movie in movies
                              where movie.title.Contains(s) || movie.tagline.Contains(s)
                              select movie;
            //return queryMovies;
            return movies;
        }
        public IEnumerable<Movie> GetMoviesByTitle(string title)
        {
            var queryMovies = from movie in movies
                              where movie.title.Contains(title)
                              select movie;
            return queryMovies;
        }
        public IEnumerable<Movie> GetMoviesByActor(string actor)
        {
            throw new NotImplementedException();
        }

        public void CreateMovie(Movie m)
        {
            movies.Add(m);
        }

        public void UpdateMovie(int id, Movie m)
        {
            if (id < movies.Count())
            {
                movies[id] = m;
            }
        }

        public void DeleteMovie(int id)
        {
            if (id < movies.Count())
            {
                movies.RemoveAt(id);
            }
        }
    }
}
