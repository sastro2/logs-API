using logs_API.Models.LogModels;
using System.ComponentModel.DataAnnotations;

namespace logs_API.Dtos
{
    public class UserJourneyDto
    {
        public int Id { get; }
        [Required]
        public int ProjectId { get; set; } = 0;
        [Required]
        public int Timestamp { get; set; } = 0;
        [Required]
        public ReqLogDto[] Logs { get; set; } = Array.Empty<ReqLogDto>();
    }
}
