using Microsoft.EntityFrameworkCore;
using BookTrackerAPI.Models;

namespace BookTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //represents the Books table in database with ability to query
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                // Convert List<string> to comma-separated string for database
                entity.Property(e => e.Genres)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    );
            });

            // Seed some initial data
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    GoogleBooksId = "sample1",
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    PageCount = 310,
                    Description = "A fantasy adventure about Bilbo Baggins",
                    Genres = new List<string> { "Fantasy", "Adventure" },
                    Status = ReadingStatus.Finished,
                    Rating = 5,
                    Review = "An absolute classic!",
                    AddedAt = DateTime.Now.AddDays(-35),
                    UpdatedAt = DateTime.Now.AddDays(-30),
                    FinishedReadingDate = DateTime.Now.AddDays(-30)
                },
                new Book
                {
                    Id = 2,
                    GoogleBooksId = "sample2",
                    Title = "1984",
                    Author = "George Orwell",
                    PageCount = 328,
                    Description = "A dystopian social science fiction novel",
                    Genres = new List<string> { "Science Fiction", "Dystopian" },
                    Status = ReadingStatus.CurrentlyReading,
                    AddedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now.AddDays(-5),
                    StartedReadingDate = DateTime.Now.AddDays(-5)
                }
            );
        }
    }
}
