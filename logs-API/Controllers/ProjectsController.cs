using logs_API.Data;
using logs_API.Interfaces;
using logs_API.Repo.ProjectControllerRepo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProjects _ProjectsInterface;

        public ProjectsController(DataContext context)
        {
            _context = context;
            _ProjectsInterface = new ProjectRepo();
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> CreateProject(int userId)
        {
            await _ProjectsInterface.CreateProject(_context, userId);
            return Ok();
        }
    }
}
