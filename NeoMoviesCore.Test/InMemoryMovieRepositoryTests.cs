using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoMoviesCore.Common.Model;
using NeoMoviesCore.Common.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace NeoMoviesCore.Test
{
    [TestClass]
    public class InMemoryMovieRepositoryTests
    {
        [TestMethod]
        public void Constructor_InMemoryMovieRepository()
        {
            // Empty list movie when initialize 
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);
        }

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

        [TestMethod]
        public void SearchMoviesByString_Test()
        {
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            List<Movie> ms = new List<Movie>();

            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };

            /*************************************
             * 1 movies
             *************************************/
            ms.Add(m);
            repo.CreateMovie(m);
            // Test string in title
            CollectionAssert.AreEqual(repo.SearchMoviesByString("Tit").ToList(), ms);
            // Test string in tagline
            CollectionAssert.AreEqual(repo.SearchMoviesByString("This").ToList(), ms);
            // Test string in both title and tagline
            CollectionAssert.AreEqual(repo.SearchMoviesByString("T").ToList(), ms);

            /*************************************
             * Multi movies
             *************************************/
            Movie m1 = new Movie { title = "Wall-E", released = 2008, tagline = "This is a cool tagline" };
            List<Movie> ms1 = new List<Movie>();
            ms.Add(m1);
            ms1.Add(m1);
            repo.CreateMovie(m1);

            // Test string in title
            CollectionAssert.AreEqual(repo.SearchMoviesByString("Wall").ToList(), ms1);
            // Test string in tagline
            CollectionAssert.AreEqual(repo.SearchMoviesByString("This").ToList(), ms);
            // Test string in both title and tagline
            CollectionAssert.AreEqual(repo.SearchMoviesByString("T").ToList(), ms);
        }

        [TestMethod]
        public void GetMoviesByTitle_Test()
        {
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            List<Movie> ms = new List<Movie>();
            List<Movie> empty = new List<Movie>();
            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };

            /*************************************
             * 1 movies
             *************************************/
            ms.Add(m);
            repo.CreateMovie(m);
            // Test string in title
            CollectionAssert.AreEqual(repo.SearchMoviesByString("Tit").ToList(), ms);
            // Test not found
            CollectionAssert.AreEqual(repo.SearchMoviesByString("Tt").ToList(), empty);

            /*************************************
             * Multi movies
             *************************************/
            Movie m1 = new Movie { title = "Wall-E", released = 2008, tagline = "This is a cool tagline" };
            List<Movie> ms1 = new List<Movie>();
            ms1.Add(m1);
            repo.CreateMovie(m1);

            // Test string in title
            CollectionAssert.AreEqual(repo.SearchMoviesByString("Wall").ToList(), ms1);
            // Test not found
            CollectionAssert.AreEqual(repo.SearchMoviesByString("Tt").ToList(), empty);
        }
    }
}
