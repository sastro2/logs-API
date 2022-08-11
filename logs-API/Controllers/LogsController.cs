using Microsoft.AspNetCore.Mvc;
using logs_API.Dtos;
using logs_API.Data;
using Microsoft.AspNetCore.Cors;
using logs_API.Models.LogModels.Database;
using logs_API.Interfaces;
using logs_API.Repo;
using logs_API.Models.Response;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
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
                .Select(x => new ResLogDto { Id = x.Id, Message = x.Message, ProjectId = x.UserJourney.ProjectId, Type = x.LogType.Name }).ToList();

            return logsDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResLogDto>> GetLog(int id)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            // Check if specified log is part of that project if not return

            if (typeof(int) != id.GetType())
                return BadRequest(new Error { Message = "Must specify an Id of type integer", ErrorCode = 0002 });


            DbLog? log = await _LogsInterface.GetLog(_context, id);

            if (log == null)
                return NotFound(new Error { Message = "Did not find Log with id" + " " + id.ToString(), ErrorCode = 0001 });

            ResLogDto logDto = new() { Id = log.Id, Message = log.Message, ProjectId = log.UserJourney.ProjectId, Type = log.LogType.Name };
            return logDto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateLogs([FromBody] UserJourneyDto userJourneyDto)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            if(userJourneyDto.Id.GetType() != typeof(int) || 
                userJourneyDto.Timestamp.GetType() != typeof(int) || 
                userJourneyDto.ProjectId.GetType() != typeof(int) ||
                userJourneyDto.Logs.GetType() != typeof(ReqLogDto[]))
            {
                return BadRequest(new Error { Message = "Invalid type please make sure type matches userJourney", ErrorCode = 0003 });
            }

            Error? error = await _LogsInterface.CreateLogs(_context, userJourneyDto);

            if(error != null)
            {
                return BadRequest(error);
            }

            return CreatedAtAction(nameof(_LogsInterface.GetLogs), userJourneyDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLog(int id)
        {
            // TODOS

            // Check if credentials correct if not return

            // Check if project exists if not return

            // Check if user has access to project if not return

            // Check if specified log is part of that project if not return

            if(typeof(int) != id.GetType())
                return BadRequest(new Error { Message = "Must specify an Id of type integer", ErrorCode = 0002 });
            

            DbLog? log = await _LogsInterface.GetLog(_context, id);

            if (log == null)
                return NotFound(new Error { Message = "Did not find Log with id" + " " + id.ToString(), ErrorCode = 0001 });

            await _LogsInterface.DeleteLog(_context, log);
            return Ok();
        }
    }
}
