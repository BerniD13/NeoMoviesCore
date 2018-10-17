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

            var testMovie = new Movie();
            testMovie.title = "John's Movie";
            testMovie.released = 2000;
            testMovie.tagline = "Test Movie";

            movies.Add(testMovie);
        }
        public IEnumerable<Movie> SearchMoviesByString(string s)
        {
            var queryMovies = from movie in movies
                              where movie.title.Contains(s) || movie.tagline.Contains(s)
                              select movie;
            return queryMovies;
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

        public void UpdateMovie(Movie m)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(Movie m)
        {
            throw new NotImplementedException();
        }
    }
}
