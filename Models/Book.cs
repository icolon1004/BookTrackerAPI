using System.ComponentModel.DataAnnotations;

namespace BookTrackerAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string GoogleBooksId { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(300)]
        public string Author { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? ISBN { get; set; }

        [MaxLength(1000)]
        public string? CoverImageUrl { get; set; }


        public int? PageCount { get; set; }
        public DateTime? PublishedDate { get; set; }

        [MaxLength(2000)]
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
