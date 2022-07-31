using logs_API.Models.LogModels;

namespace logs_API.Interfaces.LogsInterface
{
    public interface ILogs
    {
        public IEnumerable<DbLog>? GetLogs();
        public DbLog? GetLog(string id);
        public void CreateLogs(UserJourney userJourney);
        public void DeleteLog(string id);
    }
}
