using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirtualLibrarian.Model
{
    public struct Publisher
    {
        private static int count;
        [JsonProperty]
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public Publisher(string name, string country, string description = "")
        {
            ID = Interlocked.Increment(ref count);
            Name = name;
            Country = country;
            Description = description;
        }
    }
}
