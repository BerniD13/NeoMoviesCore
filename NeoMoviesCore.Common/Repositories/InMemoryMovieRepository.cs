using System;
using System.Collections.Generic;
using System.Text;
using NeoMoviesCore.Common.Model;

namespace NeoMoviesCore.Common.Repositories
{
    class InMemoryMovieRepository : IMovieRepository
    {
        public IEnumerable<Movie> SearchMoviesByString(string s)
        {
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.Title = "Movie";
            testMovie.Released = 2000;
            testMovie.Tagline = "Test movie, searched string: " + s;

            movieList.Add(testMovie);

            return movieList;
        }
        public IEnumerable<Movie> GetMoviesByTitle(string title)
        {
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.Title = "Movie";
            testMovie.Released = 2000;
            testMovie.Tagline = "Test movie, searched string: " + title;

            movieList.Add(testMovie);

            return movieList;
        }
        public IEnumerable<Movie> GetMoviesByActorName(string name)
        {
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.Title = "Movie";
            testMovie.Released = 2000;
            testMovie.Tagline = "Test movie, searched string: " + name;

            movieList.Add(testMovie);

            return movieList;
        }

        public IEnumerable<Movie> GetMoviesByActor(Actor actor)
        {
            return GetMoviesByActorName(actor.Name);
        }
    }
}
