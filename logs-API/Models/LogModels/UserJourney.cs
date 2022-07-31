using System.ComponentModel.DataAnnotations;

namespace logs_API.Models.LogModels
{
    public class UserJourney
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required]
        public int ProjectId { get; set; } = 0;
        [Required]
        public int Timestamp { get; set; } = 0;
        [Required]
        public ReqLog[] Logs { get; set; } = Array.Empty<ReqLog>();
    }
}
