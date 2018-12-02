﻿using Newtonsoft.Json;
using System.Threading;

namespace VirtualLibrarian.Model
{
    public struct Author
    {
        private static int count;
        [JsonProperty]
        public int ID { get;private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => $"{Name} {Surname}";
        public string Country { get; set; }
        public string Description { get; set; }

        public Author(string name, string surname, string country="", string description="")
        {
            ID = Interlocked.Increment(ref count);
            Name = name;
            Surname = surname;
            Country = country;
            Description = description;
        }



    }
}