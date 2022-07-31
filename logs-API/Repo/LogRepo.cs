using logs_API.Interfaces.LogsInterface;
using logs_API.Models.Logs;

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

        public ReqLog GetLog(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReqLog> GetLogs()
        {
            throw new NotImplementedException();
        }
    }
}
