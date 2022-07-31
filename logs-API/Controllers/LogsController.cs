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
            //_LogsInterface = new InMemLogRepo();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResLogDto>> GetLogs()
        {
            IEnumerable<DbLog>? logs = _LogsInterface.GetLogs();

            if (logs == null)
                return NotFound();

            var logsDto = logs
                .Select(x => new ResLogDto { Id = x.Id, Message = x.Message, ProjectId = x.ProjectId, Type = x.Type }).ToList();

            return logsDto;
        }

        [HttpGet("{id}")]
        public ActionResult<ResLogDto> GetLog(string id)
        {
            DbLog? log = _LogsInterface.GetLog(id);
            
            if(log == null) 
                return NotFound();

            ResLogDto logDto = new() { Id = log.Id, Message = log.Message, ProjectId = log.ProjectId, Type = log.Type };
            return logDto;
        }

        [HttpPost]
        public ActionResult CreateLogs(UserJourneyDto userJourneyDto)
        {
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
