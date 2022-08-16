using logs_API.Data;
using logs_API.Dtos;
using logs_API.Interfaces;
using logs_API.Models.ResponseModels;
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

        [HttpGet("{projectId}")]
        public ActionResult<List<TypeDto>> GetTypes(int projectId)
        {
            List<TypeDto> types = _TypesInterface.GetTypes(_context, projectId);

            return types;
        }

        [HttpPost]
        public async Task<ActionResult> CreateType([FromBody] TypeDto type)
        {
            if(typeof(string) != type.Name.GetType() ||
                typeof(int) != type.ProjectId.GetType() ||
                typeof(bool) != type.SendImmediately.GetType())
            {
                return BadRequest(new Error { Message = "Invalid type please make sure type matches logType", ErrorCode = 0005 });
            }

            Error? error = await _TypesInterface.CreateType(_context, type.Name, type.ProjectId, type.SendImmediately);

            if (error != null)
                return NotFound(error);

            return Ok();
        } 
    }
}
