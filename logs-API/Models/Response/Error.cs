﻿namespace logs_API.Models.Response
{
    public class Error
    {
        public string Message { get; set; } = string.Empty;
        public int ErrorCode { get; set; }
        public string Documentation { get; set; } = string.Empty;
    }
}
