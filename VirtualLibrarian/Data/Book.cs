using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Book
    {

        public static int count;
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public Genre Genre { get; set; }
        public Status Status { get; set; }

        public int Reader { get; set; }
        

        public Book()
        {
            ID = ++count;
            Status = Status.Available;
        }

        public Book(string title, string author, string publisher, Genre genre, string isbn, string description = "") : this()
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ISBN = isbn;
            Description = description;
            Genre = genre;
        }

        public void Issue(User reader)
        {
            Status = Status.Taken;
            Reader = reader.ID;
        }

        public void Return()
        {
            Status = Status.Available;
            Reader = -1;
        }

    }

    //TODO implement
    [Flags]
    public enum Genre
    {
        ScienceFiction,
        Satire,
        Drama,
        ActionAdventure,
        Romance,
        Mystery,
        Horror,
        SelfHelp,
        Health,
        Guide,
        Travel,
        Childrens,
        ReligionSpirituality,
        Science,
        History,
        Math,
        Anthology,
        Poetry,
        Encyclopedias,
        Dictionaries,
        Comics,
        Art,
        Cookbooks,
        Diaries,
        Journals,
        PrayerBooks,
        Series,
        Trilogy,
        Biographies,
        Autobiographies,
        Fantasy
    }

    public enum Status
    {
        Available,
        Reserved,
        Taken
    }

}
