using System;
using System.Collections.Generic;
using System.Text;
using NeoMoviesCore.Common.Model;

namespace NeoMoviesCore.Common.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> SearchMoviesByString(string s);
		IEnumerable<Movie> SearchMoviesById(int id);
		IEnumerable<Movie> GetMoviesByTitle(string title);
        IEnumerable<Movie> GetMoviesByActor(string actor);
    }
}
