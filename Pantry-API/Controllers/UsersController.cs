using Microsoft.AspNetCore.Mvc;
using Business.UserServices;
using Common.Models.Users;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pantry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var results = await _userServices.GetAllUsersAsync();
            return StatusCode(results.StatusCode, results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await _userServices.GetUserByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto createUserDto)
        {
            var result = await _userServices.CreateUserAsync(createUserDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {   var result = await _userServices.DeleteUserAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
