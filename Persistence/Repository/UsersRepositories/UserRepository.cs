using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Repository.UsersRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PantryDbContext _context;

        public UserRepository(PantryDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
             return await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task<int> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.ID;
        }
    }
}
