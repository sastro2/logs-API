using logs_API.Models.LogModels;
using System.ComponentModel.DataAnnotations;

namespace logs_API.Dtos
{
    public class UserJourneyDto
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required]
        public int ProjectId { get; set; } = 0;
        [Required]
        public int Timestamp { get; set; } = 0;
        [Required]
        public ReqLogDto[] Logs { get; set; } = Array.Empty<ReqLogDto>();
    }
}
