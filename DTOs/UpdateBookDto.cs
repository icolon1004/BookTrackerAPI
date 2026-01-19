using BookTrackerAPI.Models;

namespace BookTrackerAPI.DTOs
{
    public class UpdateBookDto
    {
        public ReadingStatus? Status { get; set; }
        public int? Rating { get; set; }
        public string? Review { get; set; }
        public string? PersonalNotes { get; set; }
        public DateTime? StartedReadingDate { get; set; }
        public DateTime? FinishedReadingDate { get; set; }
    }
}
