using Business.ServiceResponder;
using Common.Models.Users;

namespace Business.UserServices
{
    public interface IUserServices
    {
        Task<ServiceResponse<List<UserDto>>> GetAllUsersAsync();
        Task<ServiceResponse<UserDto>> GetUserByIdAsync(int id);
        Task<ServiceResponse<int>> CreateUserAsync(CreateUserDto createUserDto);
        Task <ServiceResponse<int>> DeleteUserAsync(int id);
    }
}
