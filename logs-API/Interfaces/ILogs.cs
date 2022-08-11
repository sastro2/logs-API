using logs_API.Models.LogModels;
using logs_API.Data;
using logs_API.Models.LogModels.Database;
using logs_API.Dtos;
using logs_API.Models.Response;

namespace logs_API.Interfaces
{
    public interface ILogs
    {
        public Task<IEnumerable<DbLog>> GetLogs(DataContext context);
        public Task<DbLog?> GetLog(DataContext context, int id);
        public Task<Error?> CreateLogs(DataContext context, UserJourneyDto userJourney);
        public Task DeleteLog(DataContext context, DbLog log);
    }
}
