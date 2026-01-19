using BookTrackerAPI.Models;
using BookTrackerAPI.DTOs;

namespace BookTrackerAPI.Services
{
    public interface IBookService
    {
                                                  //=null needs to be declared in parameters//
        Task<List<Book>> GetAllBooksAsync(ReadingStatus? status = null, int? minRating = null);
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(CreateBookDto bookDto);
        Task<Book?> UpdateBookAsync(int id, UpdateBookDto updateDto);
        Task<bool> DeleteBookAsync(int id);
        Task<List<Book>> SearchBooksAsync(string query);
        Task<Dictionary<string, int>> GetGenreStatisticsAsync();
        Task<ReadingStatistics> GetReadingStatisticsAsync();

    }

    public class ReadingStatistics
    {
        public int TotalBooks {  get; set; }
        public int BooksRead { get; set; }
        public int CurrentlyReading { get; set; }
        public int WantToRead { get; set; }
        public double AverageRating { get; set; }
        public int TotalPagesRead { get; set; }
        public string? FavoriteGenre { get; set; }
    }
}
