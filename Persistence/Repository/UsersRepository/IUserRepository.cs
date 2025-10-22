using Common.Models.Users;

namespace Persistence.Repository.UsersRepository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateUserDto createUserDto);
        Task<int> DeleteAsync(int id);
    }
}
