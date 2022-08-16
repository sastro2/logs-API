using System.ComponentModel.DataAnnotations;

namespace logs_API.Dtos
{
    public record ResLogDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserJourneyId { get; set; }
        [Required]
        public int Timestamp { get; set; } = 0;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
