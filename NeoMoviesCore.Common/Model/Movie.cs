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
        
        public List<Actor> Cast { get; set; }
        public List<Director> Directors { get; set; }
        public List<Producer> Producers { get; set; }
        public List<Person> Crew
        {
            get
            {
                List<Person> l = new List<Person>();
                l.AddRange(Directors);
                l.AddRange(Producers);
                l.AddRange(Cast);
                return l;
            }
        }
    }
}
