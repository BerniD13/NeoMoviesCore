using System;
using System.Collections.Generic;
using System.Text;

namespace NeoMoviesCore.Common.Model
{
    public class Movie
    {
        public string title { get; set; }
        public int released { get; set; }
        public string tagline { get; set; }

        public list<Actor> { get; set; }
        public list<Directors> { get; set; }
        public list<Producers> { get; set; }
    }
}
