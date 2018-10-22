using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoMoviesCore.Common.Model;
using NeoMoviesCore.Common.Repositories;
using System.Linq;

namespace NeoMoviesCore.Test
{
    [TestClass]
    public class InMemoryMovieRepositoryTests
    {
        [TestMethod]
        public void CreateMovie_AddsToList()
        {
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);
            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);

        }

        [TestMethod]
        public void DeleteMovie_RemovesFromList()
        {
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);
            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);
            repo.DeleteMovie(0);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);

        }

        [TestMethod]
        public void UpdateMovie_ChangesMovie()
        {
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);
            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);

            Movie m2 = new Movie { title = "New Title", released = 2001, tagline = "Tag" };
            repo.UpdateMovie(0, m2);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);
            Assert.AreEqual(repo.GetAllMovies().First().title, "New Title");
            Assert.AreEqual(repo.GetAllMovies().First().released, 2001);
            Assert.AreEqual(repo.GetAllMovies().First().tagline, "Tag");
        }
    }
}
