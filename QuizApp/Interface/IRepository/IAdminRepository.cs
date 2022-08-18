using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuizApp.DTO;
using QuizApp.Entities;

namespace QuizApp.Interface
{
    public interface IAdminRepository
    {
        public Task<IdentityResult> CraeteAdmin(Admin admin, CancellationToken cancellationToken);
        public Task<IdentityResult> UpdateAdmin(Admin admin, CancellationToken cancellationToken);
        public Task<IdentityResult> DeleteAdmin(int id, CancellationToken cancellationToken);
        public Task<IList<AdminDTO>> GetAllAdmin(CancellationToken cancellationToken);
        public Task<AdminDTO> GetAdminById(int id, CancellationToken cancellationToken);


        
    }
}
