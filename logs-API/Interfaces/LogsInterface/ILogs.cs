using logs_API.Models.LogModels;
using logs_API.Data;
using logs_API.Models.LogModels.Database;
using logs_API.Dtos;

namespace logs_API.Interfaces.LogsInterface
{
    public interface ILogs
    {
        public Task<IEnumerable<DbLog>> GetLogs(DataContext context);
        public Task<DbLog?> GetLog(DataContext context, string id);
        public Task CreateLogs(DataContext context, UserJourneyDto userJourney);
        public Task DeleteLog(DataContext context, DbLog log);
    }
}
