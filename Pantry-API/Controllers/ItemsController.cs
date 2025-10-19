using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pantry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly PantryDbContext dbContext;

        public ItemsController(PantryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(dbContext.Items.Include(i => i.Category.Name).ToList());
        }
        
    }
}
