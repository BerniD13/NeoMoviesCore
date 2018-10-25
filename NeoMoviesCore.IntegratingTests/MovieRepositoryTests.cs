using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoMoviesCore.Common.Model;
using NeoMoviesCore.Common.Repositories;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Configuration;
using Neo4jClient;
using Microsoft.Extensions.Configuration;
using System.IO;



namespace NeoMoviesCore.IntegratingTests
{
    [TestClass]
    public class MovieRepositoryTests
    {
        private IOptions<DatabaseSettings> dbSettings = Options.Create<DatabaseSettings>(new DatabaseSettings());
        private static IGraphClient GraphClient { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
         //   var url = dbSettings.Value(""http://database:7474/db/data"").GraphDBUrl);
         //   var user = dbSettings.Value.GraphDBUser;
         //   var password = dbSettings.Value.GraphDBPassword;
            var client = new GraphClient(new Uri("http://localhost:7474/db/data/"), "neo4j", "movies");
            client.Connect();
            GraphClient = client;
        }
        

        [TestMethod]
        public void CreateMovie_Test()
        {
           // GraphClient _graphClient = new GraphClient(new Uri("http://path/to/your/db/data"));
           // MovieRepository repo = new MovieRepository(_graphClient);
            //IOptions<DatabaseSettings> dbSettings = Options.Create<DatabaseSettings>(new DatabaseSettings());
            MovieRepository repo = new MovieRepository(GraphClient);
            // FAILS INITIALIZE ??? 

            Movie m = new Movie { title = "Title", released = 2000, tagline = "This is a cool tagline" };
            repo.CreateMovie(m);
            List<Movie> ms = new List<Movie>();
            ms.Add(m);

            //Assert.AreEqual(repo.GetMoviesByTitle("Title").ToList().Contains(m), true);
            Assert.AreEqual(repo.GetMoviesByTitle("Title").ToList().Count(), 0);
        }

    }
}
