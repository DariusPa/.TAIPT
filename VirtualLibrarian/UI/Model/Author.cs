using Newtonsoft.Json;
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

        public Author(string name, string surname)
        {
            ID = Interlocked.Increment(ref count);
            Name = name;
            Surname = surname;
        }



    }
}