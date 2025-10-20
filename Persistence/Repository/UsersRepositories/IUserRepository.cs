using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;

namespace Persistence.Repository.UsersRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<int> CreateAsync(User user);
    }
}
