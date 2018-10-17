﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeoMoviesCore.Common.Model
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Actor : Person
    {
    }

    public class Director : Person
    {
    }

    public class Producer : Person
    {
    }
}
