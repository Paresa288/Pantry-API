using Common.Models.Users;
using Persistence.Repository.UsersRepository;
using Business.ServiceResponder;
using Persistence.Entities;

namespace Business.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<ServiceResponse<List<UserDto>>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            
            return ServiceResponse<List<UserDto>>._Success(users, 200);
        }

        public async Task<ServiceResponse<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return ServiceResponse<UserDto>.Fail("User not found", 404);
            }
            
            return ServiceResponse<UserDto>._Success(user, 200);

        }
        
        public async Task<ServiceResponse<int>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
            };

            int userId = await _userRepository.CreateAsync(createUserDto);
            return ServiceResponse<int>._Success(userId, 201);
        }
        
        public async Task<ServiceResponse<int>> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return ServiceResponse<int>.Fail("User not found", 404);
            }
            await _userRepository.DeleteAsync(id);
            return ServiceResponse<int>._Success(id, 200);
        }
    }
}
