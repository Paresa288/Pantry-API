using Common.Models.Users;

namespace Business.UsersService
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<int> CreateUserAsync(CreateUserDto createUserDto);
        Task <int> DeleteUserAsync(int id);
    }
}
