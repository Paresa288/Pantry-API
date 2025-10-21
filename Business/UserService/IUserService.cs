using Business.ServiceResponder;
using Common.Models.Users;

namespace Business.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserDto>>> GetAllUsersAsync();
        Task<ServiceResponse<UserDto>> GetUserByIdAsync(int id);
        Task<ServiceResponse<int>> CreateUserAsync(CreateUserDto createUserDto);
    }
}
