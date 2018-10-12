using System;
using System.Collections.Generic;
using System.Text;

namespace NeoMoviesCore.Common.Repositories
{
    public class DatabaseSettings
    {
        public string GraphDBUrl { get ; set; }
        public string GraphDBUser { get ; set; }
        public string GraphDBPassword { get; set; }
    }
}
