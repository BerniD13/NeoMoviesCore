using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoMoviesCore.Common.Model;
using NeoMoviesCore.Common.Repositories;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;


namespace NeoMoviesCore.IntegratingTests
{
    [TestClass]
    public class MovieRepositoryTests
    {
        

        [TestMethod]
        public void CreateMovie_Test()
        {
            IOptions<DatabaseSettings> dbSettings = Options.Create<DatabaseSettings>(new DatabaseSettings());
            MovieRepository repo = new MovieRepository(dbSettings);
            // FAILS INITIALIZE ??? 

            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);
            // Empty list movie when initialize 
            IEnumerable<Movie> ms = new[] { m };

            Assert.AreEqual(repo.SearchMoviesByString("Title").ToList().Count(), 1);
        }

    }
}
