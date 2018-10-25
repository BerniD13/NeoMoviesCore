using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeoMoviesCore.Test
{
    [TestClass]
    public class UnitTest1
    {
		public void init_size() {
            InMemoryMovieRepository movie_repo = new InMemoryMovieRepository();
            Assert.AreEqual(movie_repo.GetAllMovies().ToList().Count(), 0);
			Assert.notEqual(movie_repo.GetAllMovies().ToList().Count(), 0);
        }

		public void size_changes() {
            InMemoryMovieRepository movie_repo = new InMemoryMovieRepository();
            Movie Rocky = new Movie { title = "Rocky", released = 1976, tagline = "His whole life was a million to one shot" };
            repo.CreateMovie(m);
            Assert.AreEqual(movie_repo.GetAllMovies().ToList().Count(), 1);
            repo.DeleteMovie(0);
            Assert.AreEqual(movie_repo.GetAllMovies().ToList().Count(), 0);
		}

		public void acess_movie_info() {
            InMemoryMovieRepository movie_repo = new InMemoryMovieRepository();
            Movie Rocky = new Movie { title = "Rocky", released = 1976, tagline = "His whole life was a million to one shot" };
            Assert.AreEqual(repo.GetAllMovies().First().title, "Rocky");
            Assert.notEqual(repo.GetAllMovies().First().title, "Creed");
            Assert.AreEqual(repo.GetAllMovies().First().released, 1976);
            Assert.notEqual(repo.GetAllMovies().First().released, 2015);
            Assert.AreEqual(repo.GetAllMovies().First().tagline, "His whole life was a million to one shot");
            Assert.notEqual(repo.GetAllMovies().First().tagline, "Something else");         
        }
    }
}
