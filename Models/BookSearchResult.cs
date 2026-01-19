namespace BookTrackerAPI.Models
{
    public class BookSearchResult
    {
        public string GoogleBooksId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public string? Description { get; set; }
        public int? PageCount { get; set; }
        public List<string> Genres { get; set; } = new();
    }
}
