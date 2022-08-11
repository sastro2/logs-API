using logs_API.Data;
using logs_API.Interfaces;
using logs_API.Models.Response;
using logs_API.Repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
    public class TypesController: ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITypes _TypesInterface;
        public TypesController(DataContext context)
        {
            _context = context;
            _TypesInterface = new TypeRepo();
        }

        [HttpPost]
        public async Task<ActionResult> CreateType(string name, int projectId, bool sendImmediately)
        {
            if(typeof(string) != name.GetType() ||
                typeof(int) != projectId.GetType() ||
                typeof(bool) != sendImmediately.GetType())
            {
                return BadRequest(new Error { Message = "Invalid type please make sure type matches logType", ErrorCode = 0005 });
            }

            Error? error = await _TypesInterface.CreateType(_context, name, projectId, sendImmediately);

            if (error != null)
                return NotFound(error);

            return Ok();
        } 
    }
}
