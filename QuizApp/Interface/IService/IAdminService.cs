using System.Threading;
using System.Threading.Tasks;
using QuizApp.DTO;
using QuizApp.DTO.RequestModel;
using QuizApp.DTO.ResponseModel;

namespace QuizApp.Interface.IService
{
    public interface IAdminService
    {
        public Task<BaseResponse> CreatAdmin(CreateAdminRequest request, CancellationToken cancellationToken);
        public Task<BaseResponse> DeleteAdmin(int id, CancellationToken cancellationToken);
        public Task<BaseResponse> UpdateAdmin(CancellationToken cancellationToken);
        public Task<AdminResponseModel> GetAdminById(int id, CancellationToken cancellationToken);
        public Task<ListOfAdminResponseModel> GetAllAdmins(CancellationToken cancellationToken);

    }
}
