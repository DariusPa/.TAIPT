

using Newtonsoft.Json;

namespace VirtualLibrarian.Model
{
    public struct Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => $"{Name} {Surname}";

        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }



    }
}