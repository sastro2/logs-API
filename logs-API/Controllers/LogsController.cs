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
        public ActionResult<IEnumerable<LogDto>> GetLogs()
        {
            IEnumerable<DbLog>? logs = _LogsInterface.GetLogs();

            if (logs == null)
                return NotFound();

            var logsDto = logs
                .Select(x => new LogDto { Id = x.Id, Message = x.Message, ProjectId = x.ProjectId, Type = x.Type }).ToList();

            return logsDto;
        }
        [HttpGet("{id}")]
        public ActionResult<LogDto> GetLog(string id)
        {
            DbLog? log = _LogsInterface.GetLog(id);
            
            if(log == null) 
                return NotFound();

            LogDto logDto = new() { Id = log.Id, Message = log.Message, ProjectId = log.ProjectId, Type = log.Type };
            return logDto;
        }
    }
}
