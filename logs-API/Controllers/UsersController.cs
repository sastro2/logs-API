using logs_API.Data;
using logs_API.Interfaces;
using logs_API.Repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace logs_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUsers _UsersInterface;

        public UsersController(DataContext context)
        {
            _context = context;
            _UsersInterface = new UserRepo();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string username, string password)
        {
            await _UsersInterface.CreateUser(_context, username, password);
            return Ok();
        }
    }
}
