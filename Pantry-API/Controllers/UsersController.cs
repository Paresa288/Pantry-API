using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantry_API.Models;
using Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pantry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PantryDbContext dbContext;

        public UsersController(PantryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(dbContext.Users.Include(u => u.Role.Name).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = dbContext.Users.Include(u => u.Role.Name).Where(u => u.ID == id);
            
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(UserDto userDto)
        {   
            var user = new Persistence.Entities.User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                RoleId = userDto.RoleId
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return Ok(user);
        }
       
    }
}
