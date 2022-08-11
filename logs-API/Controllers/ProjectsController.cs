using logs_API.Data;
using logs_API.Dtos;
using logs_API.Interfaces;
using logs_API.Models.LogModels.Database;
using logs_API.Repo;
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

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetAllProjectsForUser(int userId)
        {
            IEnumerable<DbProject> projects = _ProjectsInterface.GetAllProjectsForUserById(_context, userId);

            List<ProjectDto> resProjects = projects.Select(p => new ProjectDto { Id = p.Id }).ToList();

            return resProjects;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> CreateProject(int userId)
        {
            await _ProjectsInterface.CreateProject(_context, userId);
            return Ok();
        }
        [HttpPost("{userId}, {projectId}")]
        public async Task<ActionResult> AddUserToProject(int userId, int projectId)
        {
            await _ProjectsInterface.AddUserToProject(_context, userId, projectId);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProjectById(int projectId)
        {
            await _ProjectsInterface.DeleteProject(_context, projectId);
            return Ok();
        }
    }
}
