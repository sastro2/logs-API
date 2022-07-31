using logs_API.Interfaces.LogsInterface;
using logs_API.Models.LogModels;

namespace logs_API.Repo
{
    public class InMemLogRepo : ILogs
    {
        private List<DbLog> _Logs;

        public InMemLogRepo()
        {
            _Logs = new() { new DbLog { Id = "12345", ProjectId = 12345, Type = "error", Message = "this is a log" } };
        }

        public void CreateLogs(UserJourney userJourney)
        { 
            foreach(ReqLog log in userJourney.Logs)
            {
                DbLog dbLog = new DbLog { Id = userJourney.Timestamp.ToString() 
                                          + "-" + userJourney.Id 
                                          + "-" + log.Timestamp.ToString(), 
                                          ProjectId = userJourney.ProjectId, Message = log.Message, Type = log.Type};

                _Logs.Add(dbLog);
            }
        } 

        public void DeleteLog(string id)
        {
            throw new NotImplementedException();
        }

        public DbLog? GetLog(string id)
        {
            var log = _Logs.Where(x => x.Id == id).SingleOrDefault();

            return log;
        }

        public IEnumerable<DbLog>? GetLogs()
        {
            return _Logs;
        }
    }
}
