using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Book).WithMany(ba => ba.book_Authors).HasForeignKey(bi => bi.BookId);
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Author).WithMany(bb => bb.book_Authors).HasForeignKey(bi => bi.AuthorId);

        }
        public DbSet <Book> Books{ get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> book_Authors { get; set; }

    }
}
