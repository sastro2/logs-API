namespace logs_API.Models.Logs
{
    public class Log
    {
        public string Id { get; set; } = string.Empty;
        public int Timestamp { get; set; } = 0;
        public string Type { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

    }
}
