using QuizApp.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Interface.Identity
{
    public interface IRoleRepository
    {
        public Task<bool> CreateRoleAsync();
        public Task<bool> UpdateRoleAsync();
        public Task<bool> DeleteRoleAsync();
        public Task<Role> GetRoleAsync(int id);
        public Task<List<Role>> GetRolesAsync();

        
    }
}
