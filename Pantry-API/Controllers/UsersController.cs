using Microsoft.AspNetCore.Mvc;
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

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(dbContext.Users.ToList());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
