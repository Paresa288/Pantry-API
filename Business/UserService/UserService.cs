using Common.Models.Users;
using Persistence.Repository.UsersRepositories;
using Business.ServiceResponder;
using Persistence.Entities;

namespace Business.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<ServiceResponse<List<UserDto>>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDto = users.Select(u => new UserDto
            {
                Name = u.Name,
                RoleId = u.RoleId,
            }).ToList();
            return new ServiceResponse<List<UserDto>>
            {
                Data = usersDto,
                Success = true,
                Message = "Users retrieved successfully."
            };
        }

        public async Task<ServiceResponse<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return ServiceResponse<int>.Fail("Invalid user ID", 400);
            }

            var userDto = new UserDto
            {
                Name = user.Name,
                RoleId = user.RoleId,
            };
            return new ServiceResponse<UserDto>
            {
                Data = userDto,
                Success = true,
                Message = "User retrieved successfully."
            };
        }
        
        public async Task<ServiceResponse<CreateUserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
            };

            int userId = await _userRepository.CreateAsync(user);
            return new ServiceResponse<CreateUserDto>
            {
                Data = createUserDto,
                Success = true,
                Message = $"User created successfully with ID: {userId}"
            };
        }
    }
}
