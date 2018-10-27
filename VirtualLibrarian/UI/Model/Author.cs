

using Newtonsoft.Json;

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
            ID = ++count;
            Name = name;
            Surname = surname;
        }



    }
}