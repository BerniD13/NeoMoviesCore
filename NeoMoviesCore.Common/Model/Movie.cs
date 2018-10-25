using System;
using System.Collections.Generic;
using System.Text;

namespace NeoMoviesCore.Common.Model
{
    public class Movie
    {
        public string Title { get; set; }
        public int Released { get; set; }
        public string Tagline { get; set; }
        
        public List<Tuple<Person, MovieRole>> Crew { get; set; }
    }
}
