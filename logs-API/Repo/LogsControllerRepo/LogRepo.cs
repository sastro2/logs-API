using logs_API.Interfaces.LogsInterface;
using logs_API.Models.LogModels;
using logs_API.Data;
using Microsoft.EntityFrameworkCore;

namespace logs_API.Repo.LogsControllerRepo
{
    public class LogRepo : ILogs
    {
        public async Task CreateLogs(DataContext context, UserJourney userJourney)
        {
            int inc = 0;

            foreach(ReqLog log in userJourney.Logs)
            {
                Console.WriteLine("HIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
                string id = userJourney.Timestamp.ToString() + "-" + userJourney.Id + "-" + log.Timestamp.ToString() + "-" + inc.ToString();
                DbLog dbLog = new() { Id = id, Message = log.Message, ProjectId = userJourney.ProjectId, Type = log.Type };

                inc += 1;

                context.Logs.Add(dbLog);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteLog(DataContext context, DbLog log)
        {
            context.Logs.Remove(log);
            await context.SaveChangesAsync();
        }

        public async Task<DbLog?> GetLog(DataContext context, string id)
        {
            DbLog? log = await context.Logs.FindAsync(id);

            return log;
        }

        public async Task<IEnumerable<DbLog>> GetLogs(DataContext context)
        {
            IEnumerable<DbLog> logs = await context.Logs.ToListAsync();

            return logs;
        }
    }
}
