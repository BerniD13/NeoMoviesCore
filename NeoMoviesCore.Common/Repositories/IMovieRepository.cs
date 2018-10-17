using System;
using System.Collections.Generic;
using System.Text;
using NeoMoviesCore.Common.Model;

namespace NeoMoviesCore.Common.Repositories
{
    public interface IMovieRepository
    {
        // Not sure what adding do yet.
        IEnumerable<Movie> AddMovie(IEnumerable<Movie> movie);
        IEnumerable<Movie> SearchMoviesByString(string s);
        IEnumerable<Movie> GetMoviesByTitle(string title);
        IEnumerable<Movie> GetMoviesByActor(string actor);
    }
}
