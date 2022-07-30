using logs_API.Interfaces.LogsInterface;
using logs_API.Models.Logs;

namespace logs_API.Repo
{
    public class InMemLogRepo : ILogs
    {
        private List<Log> _Logs;

        public InMemLogRepo()
        {
            _Logs = new() { new Log { Id = "12345", Message = "this is a log", Timestamp = 12345, Type = "error" } };
        }

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
            return _Logs;
        }
    }
}
