using logs_API.Data;
using logs_API.Interfaces.LogsInterface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
    public class ProjectsController
    {
        private readonly DataContext _context;
        private readonly IProjects _ProjectsInterface;

        public ProjectsController(DataContext context, IProjects projectsInterface)
        {
            _context = context;
            _ProjectsInterface = projectsInterface;
        }


    }
}
