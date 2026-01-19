using BookTrackerAPI.Models;

namespace BookTrackerAPI.DTOs
{
    public class CreateBookDto
    {    
        public string GoogleBooksId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public string? CoverImageUrl { get; set; }
        public int? PageCount { get; set; }
        public string? Description { get; set; }
        public List<string> Genres { get; set; } = new();
        public ReadingStatus Status { get; set; }
    }
}
