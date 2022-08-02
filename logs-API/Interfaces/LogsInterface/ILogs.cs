using logs_API.Models.LogModels;
using logs_API.Data;

namespace logs_API.Interfaces.LogsInterface
{
    public interface ILogs
    {
        public Task<IEnumerable<DbLog>> GetLogs(DataContext context);
        public Task<DbLog?> GetLog(DataContext context, string id);
        public Task CreateLogs(DataContext context, UserJourney userJourney);
        public Task DeleteLog(DataContext context, DbLog log);
    }
}
