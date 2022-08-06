using logs_API.Interfaces.LogsInterface;
using logs_API.Models.LogModels;
using logs_API.Data;
using Microsoft.EntityFrameworkCore;
using logs_API.Models.LogModels.Database;
using logs_API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace logs_API.Repo.LogsControllerRepo
{
    public class LogRepo : ILogs
    {
        public async Task CreateLogs(DataContext context, UserJourneyDto userJourney)
        {
            var project = context.Projects.FirstOrDefault(p => p.Id == userJourney.ProjectId);
            if (project == null) { return; }

            var journey = new DbUserJourney { ProjectId = userJourney.ProjectId, Timestamp = userJourney.Timestamp };

            journey.DbLogs = new List<DbLog>();
            foreach (ReqLogDto log in userJourney.Logs)
            {
                DbLogType? type = context.Types.FirstOrDefault(t => t.ProjectId == userJourney.ProjectId && t.Name == log.Type);

                if (type != null)
                {
                    DbLog dbLog = new() { Message = log.Message, LogTypeId = type.Id };
                    journey.DbLogs.Add(dbLog);
                }
            }

            context.UserJourneys.Add(journey);
            await context.SaveChangesAsync();           
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
