using Microsoft.EntityFrameworkCore;
using Common.Models;

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
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                RoleId = u.RoleId,
                FamilyId = u.FamilyId
            }).ToListAsync();

        }
        
        public async Task<UserDto?> GetByIdAsync(int id)
        {
            return await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                RoleId = u.RoleId,
                FamilyId = u.FamilyId
            }).FirstOrDefaultAsync();
        }
        
        public async Task<int> CreateAsync(CreateUserDto createUserDto)
        {
            var user = _context.Users.Add( new Entities.User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                FamilyId = createUserDto.FamilyId
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
