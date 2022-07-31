using logs_API.Interfaces.LogsInterface;
using logs_API.Models.LogModels;

namespace logs_API.Repo
{
    public class LogRepo : ILogs
    {
        public void CreateLogs(UserJourney userJourney)
        {
            throw new NotImplementedException();
        }

        public void DeleteLog(string id)
        {
            throw new NotImplementedException();
        }

        public DbLog GetLog(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DbLog> GetLogs()
        {
            throw new NotImplementedException();
        }
    }
}
