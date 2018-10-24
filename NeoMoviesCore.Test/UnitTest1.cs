using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NeoMoviesCore.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IConfigurationBuilder _config;

        [TestInitialize]
        public void TestInit()
        {
            _config = new ConfigurationBuilder();
            _config.AddJsonFile(Path.Combine(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "..", "Shared"), "SharedSettings.json"), optional: true, reloadOnChange: true);
            _config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _config.AddJsonFile($"appsettings.Test.json", optional: true, reloadOnChange: true);
            _config.Build();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            _config = null;
        }
    }
}
