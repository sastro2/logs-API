using Microsoft.AspNetCore.Mvc;
using logs_API.Interfaces.LogsInterface;
using logs_API.Models.LogModels;
using logs_API.Dtos;
using logs_API.Repo.LogsControllerRepo;
using logs_API.Data;
using Microsoft.EntityFrameworkCore;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController: ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogs _LogsInterface;

        public LogsController(DataContext context)
        {
            _context = context;
            _LogsInterface = new LogRepo();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResLogDto>>> GetLogs()
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            IEnumerable<DbLog> logs = await _LogsInterface.GetLogs(_context);

            List<ResLogDto> logsDto = logs
                .Select(x => new ResLogDto { Id = x.Id, Message = x.Message, ProjectId = x.ProjectId, Type = x.Type }).ToList();

            return logsDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResLogDto>> GetLog(string id)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            // Check if specified log is part of that project if not return

            DbLog? log = await _LogsInterface.GetLog(_context, id);
            
            if(log == null) 
                return NotFound();

            ResLogDto logDto = new() { Id = log.Id, Message = log.Message, ProjectId = log.ProjectId, Type = log.Type };
            return logDto;
        }

        [HttpPost("{userJourney}")]
        public async Task<ActionResult> CreateLogs([FromBody] UserJourneyDto userJourneyDto)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            Console.WriteLine("I AM HERE 111111111111111111111111111");

            ReqLog[] reqLogs = Array.ConvertAll(userJourneyDto.Logs, log
                => new ReqLog() { Message = log.Message, Timestamp = log.Timestamp, Type = log.Type });

            Console.WriteLine("I AM HERE 2222222222222222222222222");

            UserJourney userJourney = new() { Id = userJourneyDto.Id, 
                                              Logs = reqLogs, 
                                              ProjectId = userJourneyDto.ProjectId, 
                                              Timestamp = userJourneyDto.Timestamp };

            Console.WriteLine("I AM HERE 33333333333333333333333333");

            await _LogsInterface.CreateLogs(_context, userJourney);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLog(string id)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            // Check if specified log is part of that project if not return

            DbLog? log = await _LogsInterface.GetLog(_context, id);
            if (log == null)
                return NotFound();

            await _LogsInterface.DeleteLog(_context, log);
            return Ok();
        }
    }
}
