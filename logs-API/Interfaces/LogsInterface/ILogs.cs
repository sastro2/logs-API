using logs_API.Models.Logs;

namespace logs_API.Interfaces.LogsInterface
{
    public interface ILogs
    {
        public IEnumerable<Log> GetLogs();
        public Log GetLog(string id);
        public void CreateLogs(UserJourney userJourney);
        public void DeleteLog(string id);
    }
}
