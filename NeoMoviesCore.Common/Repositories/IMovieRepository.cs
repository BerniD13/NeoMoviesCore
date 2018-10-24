using System;
using System.Collections.Generic;
using System.Text;
using NeoMoviesCore.Common.Model;

namespace NeoMoviesCore.Common.Repositories
{
    public interface IMovieRepository
    {
        // ReadMovie
        IEnumerable<Movie> SearchMoviesByString(string s);
        IEnumerable<Movie> GetMoviesByTitle(string title);
        IEnumerable<Movie> GetMoviesByActor(string actor);

        // SearchController
        IEnumerable<Movie> SearchMoviesById(int id);

        // Add CRUD operations
        void CreateMovie(Movie m);
        void UpdateMovie(int id, Movie m);
        void DeleteMovie(int id);
    }
}
