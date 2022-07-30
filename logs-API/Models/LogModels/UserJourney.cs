namespace logs_API.Models.Logs
{
    public class UserJourney
    {
        public string Id { get; set; } = string.Empty;
        public int Timestamp { get; set; } = 0;
        public Log[] Logs { get; set; } = Array.Empty<Log>();
    }
}
