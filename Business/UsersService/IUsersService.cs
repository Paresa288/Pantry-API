using Business.ServiceResponder;
using Common.Models.Users;

namespace Business.UsersService
{
    public interface IUsersService
    {
        Task<ServiceResponse<List<UserDto>>> GetAllUsersAsync();
        Task<ServiceResponse<UserDto>> GetUserByIdAsync(int id);
        Task<ServiceResponse<int>> CreateUserAsync(CreateUserDto createUserDto);
        Task <ServiceResponse<int>> DeleteUserAsync(int id);
    }
}
