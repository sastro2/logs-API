﻿using System.ComponentModel.DataAnnotations;

namespace logs_API.Models.Logs
{
    public class Log
    {
        [Required]
        public string Id { get; set; } = string.Empty;
        [Required]
        public int Timestamp { get; set; } = 0;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;

    }
}
