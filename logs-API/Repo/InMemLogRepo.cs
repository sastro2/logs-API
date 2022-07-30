using logs_API.Models.Logs;

namespace logs_API.Repo
{
    public class InMemLogRepo : ILogs
    {
        public void CreateLogs(UserJourney userJourney)
        {
            throw new NotImplementedException();
        }

        public void DeleteLog(string id)
        {
            throw new NotImplementedException();
        }

        public Log GetLog(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetLogs()
        {
            throw new NotImplementedException();
        }
    }
}
