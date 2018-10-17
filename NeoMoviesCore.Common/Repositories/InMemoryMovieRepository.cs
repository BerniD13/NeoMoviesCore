﻿using System;
using System.Collections.Generic;
using System.Text;
using NeoMoviesCore.Common.Model;

namespace NeoMoviesCore.Common.Repositories
{
    class InMemoryMovieRepository : IMovieRepository
    {
        public IEnumerable<Movie> AddMovie(IEnumerable<Movie> movie)
        {
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.title = "Movie";
            testMovie.released = 2000;
            testMovie.tagline = "Test movie, searched string: ";

            movieList.Add(testMovie);

            return movieList;
        }

        public IEnumerable<Movie> SearchMoviesByString(string s)
        {
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.title = "Movie";
            testMovie.released = 2000;
            testMovie.tagline = "Test movie, searched string: " + s;

            movieList.Add(testMovie);

            return movieList;
        }
        public IEnumerable<Movie> GetMoviesByTitle(string title)
        {
            var movieList = new List<Movie>();

            var testMovie = new Movie();
            testMovie.title = "Movie";
            testMovie.released = 2000;
            testMovie.tagline = "Test movie, searched string: " + title;

            movieList.Add(testMovie);

            return movieList;
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
    }
}
