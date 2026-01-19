namespace BookTrackerAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string GoogleBooksId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public string? CoverImageUrl { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Description { get; set; }
        public List<string> Genres { get; set; } = new();
        public ReadingStatus Status { get; set; }
        public int? Rating { get; set; }
        public string? Review { get; set; }
        public string? PersonalNotes { get; set; }
        public DateTime? StartedReadingDate { get; set; }
        public DateTime? FinishedReadingDate { get;set; }
        public DateTime AddedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public enum ReadingStatus
    {
        WantToRead,
        CurrentlyReading,
        Finished
    }
}
