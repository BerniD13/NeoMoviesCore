using System;
using System.Collections.Generic;
using System.Text;

namespace NeoMoviesCore.Common.Model
{
    public class MovieRole
    {
        public int Salary { get; set; }
    }

    public class ActorRole : MovieRole
    {
        public string Character { get; set; }
    }

    public class DirectorRole : MovieRole
    {
    }

    public class ProducerRole : MovieRole
    {
    }
}
