using Microsoft.AspNetCore.Mvc;
using logs_API.Interfaces.LogsInterface;
using logs_API.Repo;
using logs_API.Models.LogModels;
using logs_API.Dtos;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("logs")]
    public class LogsController: ControllerBase
    {
        private ILogs _LogsInterface;

        public LogsController(ILogs logs)
        {
            _LogsInterface = logs;
        }

        [HttpGet("{username, password}")]
        public ActionResult<IEnumerable<ResLogDto>> GetLogs(string username, string password, int projectdId)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            IEnumerable<DbLog>? logs = _LogsInterface.GetLogs();

            if (logs == null)
                return NotFound();

            var logsDto = logs
                .Select(x => new ResLogDto { Id = x.Id, Message = x.Message, ProjectId = x.ProjectId, Type = x.Type }).ToList();

            return logsDto;
        }

        [HttpGet("{username, password, id}")]
        public ActionResult<ResLogDto> GetLog(string username, string password, string id)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            // Check if specified log is part of that project if not return

            DbLog? log = _LogsInterface.GetLog(id);
            
            if(log == null) 
                return NotFound();

            ResLogDto logDto = new() { Id = log.Id, Message = log.Message, ProjectId = log.ProjectId, Type = log.Type };
            return logDto;
        }

        [HttpPost("{username, password, projectId, userJourney}")]
        public ActionResult CreateLogs(string username, string password, int projectId,  UserJourneyDto userJourneyDto)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            ReqLog[] reqLogs = Array.ConvertAll(userJourneyDto.Logs, log
                => new ReqLog() { Message = log.Message, Timestamp = log.Timestamp, Type = log.Type });

            UserJourney userJourney = new() { Id = userJourneyDto.Id, 
                                              Logs = reqLogs, 
                                              ProjectId = userJourneyDto.ProjectId, 
                                              Timestamp = userJourneyDto.Timestamp };

            _LogsInterface.CreateLogs(userJourney);

            return Ok();
        }
    }
}
