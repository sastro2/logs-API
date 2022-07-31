using System.ComponentModel.DataAnnotations;

namespace logs_API.Models.LogModels
{
    public class ReqLog
    {
        [Required]
        public int Timestamp { get; set; } = 0;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;

    }
}
