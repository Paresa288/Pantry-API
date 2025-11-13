using Common.Models.Users;
using Persistence.Repository.UsersRepository;

namespace Business.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
            return await _userRepository.GetByIdAsync(id);
        }
        
        public async Task<int> CreateUserAsync(CreateUserDto createUserDto)
        {
            return await _userRepository.CreateAsync(createUserDto);
        }
        
        public async Task<int> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
