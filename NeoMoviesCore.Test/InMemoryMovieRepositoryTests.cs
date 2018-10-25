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
            // Make repo, empty at first
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);

            // Add one movie
            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);

            // Repo should now have one element in it
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);

            // Add second movie
            Movie m2 = new Movie { title = "Title2", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m2);

            // Repo should now have two elements, new element added to end of list
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 2);
            Assert.AreEqual(repo.GetAllMovies().ToList()[1].title, "Title2");
        }

        [TestMethod]
        public void DeleteMovie_RemovesFromList()
        {
            // Make repo and add one element
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);
            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);

            // List should lose one element when delete is called
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);
            repo.DeleteMovie(0);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);

            // Now add two elements
            Movie m2 = new Movie { title = "Title2", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);
            repo.CreateMovie(m2);

            // Test deleting second movie, make sure first remains in list
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 2);
            repo.DeleteMovie(1);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);
            Assert.AreEqual(repo.GetAllMovies().ToList()[0].title, "Title");

        }

        [TestMethod]
        public void UpdateMovie_ChangesMovie()
        {
            // Make one movie and add it to list
            InMemoryMovieRepository repo = new InMemoryMovieRepository();
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 0);
            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);

            // Test that all fields of movie are updated
            Movie m2 = new Movie { title = "New Title", released = 2001, tagline = "Tag" };
            repo.UpdateMovie(0, m2);
            Assert.AreEqual(repo.GetAllMovies().ToList().Count(), 1);
            Assert.AreEqual(repo.GetAllMovies().First().title, "New Title");
            Assert.AreEqual(repo.GetAllMovies().First().released, 2001);
            Assert.AreEqual(repo.GetAllMovies().First().tagline, "Tag");

            // Now add second movie and update it
            repo.CreateMovie(m2);
            Movie m3 = new Movie { title = "Newer Title", released = 2002, tagline = "Tag3" };
            repo.UpdateMovie(1, m3);

            // Test that updating worked with multiple movies
            Assert.AreEqual(repo.GetAllMovies().ToList()[1].title, "Newer Title");
            Assert.AreEqual(repo.GetAllMovies().ToList()[1].released, 2002);
            Assert.AreEqual(repo.GetAllMovies().ToList()[1].tagline, "Tag3");
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
