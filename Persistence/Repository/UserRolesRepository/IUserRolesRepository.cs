using Common.Models.UserRoles;

namespace Persistence.Repository.UserRolesRepository
{
    public interface IUserRolesRepository
    {
        public Task<List<UserRolesDto>> GetAllUserRoles();
        public Task<UserRolesDto> GetUserRoleById(int id);
        public Task<int> CreateUserRole(UserRolesDto userRolesDto);
        public Task<int> DeleteUserRole(int id);
    }
}
