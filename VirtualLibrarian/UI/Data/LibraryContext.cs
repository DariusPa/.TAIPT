using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;

namespace VirtualLibrarian.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<ReadingHistory> ReadingHistory { get; set; }

        public LibraryContext() : base() { }

        public LibraryContext(string connectionString) : base(connectionString) { }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

    }
}
