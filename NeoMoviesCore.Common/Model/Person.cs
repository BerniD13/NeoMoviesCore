using System;
using System.Collections.Generic;
using System.Text;

namespace NeoMoviesCore.Common.Model
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        /*
         * In the future, storing the movies the person worked on (as well as
         * having the movies store the crew) would allow for faster searching
         */
         public List<Tuple<Movie, MovieRole>> CareerHistory { get; set; }
    }
}
