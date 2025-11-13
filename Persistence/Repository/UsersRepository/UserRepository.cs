using Microsoft.EntityFrameworkCore;
using Common.Models.Users;

namespace Persistence.Repository.UsersRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly PantryDbContext _context;

        public UserRepository(PantryDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<UserDto>> GetAllAsync()
        {
            return await _context.Users.Select(u => new UserDto
            {
                Name = u.Name,
                Email = u.Email,
                RoleId = u.RoleId,
            }).ToListAsync();

        }
        
        public async Task<UserDto?> GetByIdAsync(int id)
        {
            return await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new UserDto
            {
                Name = u.Name,
                Email = u.Email,
                RoleId = u.RoleId,
            }).FirstOrDefaultAsync();
        }
        
        public async Task<int> CreateAsync(CreateUserDto createUserDto)
        {
            var user = _context.Users.Add( new Entities.User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
            });
            await _context.SaveChangesAsync();
            return user.Entity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
