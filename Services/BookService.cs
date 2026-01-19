using BookTrackerAPI.Models;
using BookTrackerAPI.DTOs;

namespace BookTrackerAPI.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        //Sample Books
        public BookService()
        {
            //sample book for testing
            _books.Add(new Book
            {
                Id = _nextId++,
                GoogleBooksId = "sample1",
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                CoverImageUrl = "https://covers.openlibrary.org/b/id/6979861-L.jpg",
                PageCount = 310,
                Description = " A fantasy adventure about Bilbo Baggins",
                Genres = new List<string> { "Fantasy", "Adventure" },
                Status = ReadingStatus.Finished,
                Rating = 5,
                Review = "An absolute classic! Loved every page.",
                FinishedReadingDate = DateTime.Now.AddDays(-30),
                AddedAt = DateTime.Now.AddDays(-35),
                UpdatedAt = DateTime.Now.AddDays(-30)
            });

            //sample book for testing
            _books.Add(new Book
            {
                Id = _nextId++,
                GoogleBooksId = "sample2",
                Title = "1984",
                Author = "George Orwell",
                CoverImageUrl = "https://covers.openlibrary.org/b/id/7222246-L.jpg",
                PageCount = 328,
                Description = "A dystopian social science fiction novel",
                Genres = new List<string> { "Science Fiction", "Dystopian" },
                Status = ReadingStatus.CurrentlyReading,
                StartedReadingDate = DateTime.Now.AddDays(-5),
                AddedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now.AddDays(-5)
            });
        }

        //retrieves all books in List<Book>
        public Task<List<Book>> GetAllBooksAsync(ReadingStatus? status = null, int? minRating = null)
        {
            var query = _books.AsQueryable();

            if (status.HasValue)
            {
                query = query.Where(b => b.Status == status.Value);
            }

            if (minRating.HasValue)
            {
                query = query.Where(b => b.Rating >= minRating.Value);
            }

            return Task.FromResult(query.OrderByDescending(b => b.UpdatedAt).ToList());
        }

        //retrieves all books in List<Book> by Id
        public Task<Book?> GetBookByIdAsync(int id)
        {
            return Task.FromResult(_books.FirstOrDefault(b => b.Id == id));
        }

        //creates books for List<Book>
        public Task<Book> CreateBookAsync(CreateBookDto bookDto)
        {
            //new variable for each book
            var book = new Book
            {
                Id = _nextId++,
                GoogleBooksId = bookDto.GoogleBooksId,
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                CoverImageUrl = bookDto.CoverImageUrl,
                PageCount = bookDto.PageCount,
                Description = bookDto.Description,
                Genres = bookDto.Genres,
                Status = bookDto.Status,
                AddedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            //updates date of reading status
            if (bookDto.Status == ReadingStatus.CurrentlyReading)
            {
                book.StartedReadingDate = DateTime.Now;
            }
            else if (bookDto.Status == ReadingStatus.Finished)
            {
                book.FinishedReadingDate = DateTime.Now;
            }

            //adds new book to List<Book>
            _books.Add(book);
            return Task.FromResult(book);
        }

        //updates book Dto
        public Task<Book?> UpdateBookAsync(int id, UpdateBookDto updateDto)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return Task.FromResult<Book?>(null);

            //update book reading status
            if (updateDto.Status.HasValue)
            {
                var oldStatus = book.Status;
                book.Status = updateDto.Status.Value;

                if (updateDto.Status.Value == ReadingStatus.CurrentlyReading && oldStatus == ReadingStatus.WantToRead)
                {
                    book.StartedReadingDate = DateTime.Now;
                }
                else if (updateDto.Status.Value == ReadingStatus.Finished)
                {
                    book.FinishedReadingDate = DateTime.Now;
                }
            }

            //update book rating
            if (updateDto.Rating.HasValue)
            {
                book.Rating = updateDto.Rating.Value;
            }

            //update book review
            if (updateDto.Review != null)
            {
                book.Review = updateDto.Review;
            }

            //update book personal notes
            if (updateDto.PersonalNotes != null)
            {
                book.PersonalNotes = updateDto.PersonalNotes;
            }

            //updates started reading date
            if (updateDto.StartedReadingDate.HasValue)
            {
                book.StartedReadingDate = updateDto.StartedReadingDate.Value;
            }

            //updates finished reading date
            if (updateDto.FinishedReadingDate.HasValue)
            {
                book.FinishedReadingDate = updateDto.FinishedReadingDate.Value;
            }

            book.UpdatedAt = DateTime.Now;
            return Task.FromResult<Book?>(book);
        }

        //removes book from list if it exists
        public Task<bool> DeleteBookAsync(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null) return Task.FromResult(false);

            _books.Remove(book);
            return Task.FromResult(true);
        }

        //searches for books with these properties filed out
        public Task<List<Book>> SearchBooksAsync(string query)
        {
            var lowerQuery = query.ToLower();
            var results = _books.Where(b =>
                b.Title.ToLower().Contains(lowerQuery) ||
                b.Author.ToLower().Contains(lowerQuery) ||
                b.Genres.Any(g => g.ToLower().Contains(lowerQuery))
            ).ToList();

            return Task.FromResult(results);
        }

        //counts how many books are in each genre and sorts them by popularity // useful to see what genres you are reading the most of
        public Task<Dictionary<string, int>> GetGenreStatisticsAsync()
        {
            //empty dictionary to store counts
            var genreCounts = new Dictionary<string, int>();

            //loops through books in library
            foreach (var book in _books)
            {
                //loops through each genre in each book
                foreach (var genre in book.Genres)
                {
                    //if genre has been accounted for it updates the amount of times seeing this genre for stats
                    if (genreCounts.ContainsKey(genre))
                    {
                        genreCounts[genre]++;
                    }
                    //if genre hasnt been accounted for it adds the genre to the dictionary
                    else
                    {
                        genreCounts[genre] = 1;
                    }
                }
            }

            return Task.FromResult(genreCounts.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value));
        }

        //calculates reading statistics
        public Task<ReadingStatistics> GetReadingStatisticsAsync()
        {
            //creates new object 
            var stats = new ReadingStatistics
            {
                TotalBooks = _books.Count, //counts all books in library
                BooksRead = _books.Count(b => b.Status == ReadingStatus.Finished), //counts only books that have been finished
                CurrentlyReading = _books.Count(b => b.Status == ReadingStatus.CurrentlyReading), //counts only books in progress, started but not finished
                WantToRead = _books.Count(b => b.Status == ReadingStatus.WantToRead), //counts books want to read later
                AverageRating = _books.Where(b => b.Rating.HasValue).Any()
                    ? _books.Where(b => b.Rating.HasValue).Average(b => b.Rating ?? 0) : 0, //.Any() returns true if at least one exist //Ternary Operator ? valueIfTrue : valueIfFalse 
                TotalPagesRead = _books.Where(b => b.Status == ReadingStatus.Finished && b.PageCount.HasValue)
                    .Sum(b => b.PageCount ?? 0) //shows total number of pages read from all books
            };

            var genreStats = GetGenreStatisticsAsync().Result;
            stats.FavoriteGenre = genreStats.FirstOrDefault().Key;

            return Task.FromResult(stats);
        }
    }
}
