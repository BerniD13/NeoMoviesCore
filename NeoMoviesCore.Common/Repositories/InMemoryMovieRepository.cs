using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeoMoviesCore.Common.Model;

namespace NeoMoviesCore.Common.Repositories
{
    class InMemoryMovieRepository : IMovieRepository
    {   
        // Private movie list.
        private List<Movie> movies;
        // Constructor
        public InMemoryMovieRepository()
        {
            movies = new List<Movie>();
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
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.title = "Movie";
            testMovie.released = 2000;
            testMovie.tagline = "Test movie, searched string: " + actor;

            movieList.Add(testMovie);

            return movieList;
        }

        // SearchController
        public IEnumerable<Movie> SearchMoviesById(int id)
        {
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.title = "Movie";
            testMovie.released = 2000;
            testMovie.tagline = "Test movie, searched string: " + id;

            movieList.Add(testMovie);

            return movieList;
        }

        // CRUD operations
        public void CreateMovie(Movie m)
        {
            movies.Add(m);
        }

        public void UpdateMovie(int id, Movie m)
        {
            foreach (Movie movie in SearchMoviesById(id))
            {
                movies[id] = m;
            }
        }

        public void DeleteMovie(int id)
        {
            foreach (Movie movie in SearchMoviesById(id))
            {
                movies.RemoveAt(id);
            }
        }
    }
}
