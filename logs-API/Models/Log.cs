namespace logs_API.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public string Type { get; set; } = "";
        
    }
}
