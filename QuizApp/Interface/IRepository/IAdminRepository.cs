using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.DTO;

namespace QuizApp.Interface
{
    public interface IAdminRepository
    {
        public Task<AdminDTO> CraeteAdmin();
        public Task<AdminDTO> UpdateAdmin();
        public Task<AdminDTO> DeleteAdmin();
        public Task<IList<AdminDTO>> GetAllAdmin();
        public Task<AdminDTO> GetAdminById(int id);


    }
}
