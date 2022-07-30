using Microsoft.AspNetCore.Mvc;
using logs_API.Interfaces.LogsInterface;
using logs_API.Repo;
using logs_API.Models.Logs;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("logs")]
    public class LogsController: ControllerBase
    {
        private ILogs _LogsInterface;

        public LogsController()
        {
            _LogsInterface = new InMemLogRepo();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Log>> GetLogs()
        {
            return _LogsInterface.GetLogs().ToList();
        }
    }
}
