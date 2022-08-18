using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using QuizApp.DTO;
using QuizApp.DTO.RequestModel;
using QuizApp.DTO.ResponseModel;
using QuizApp.Entities;
using QuizApp.Entities.Identity;
using QuizApp.Interface;
using QuizApp.Interface.Identity;
using QuizApp.Interface.IService;

namespace QuizApp.Implementations.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> CreatAdmin(CreateAdminRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };
            var newUser = await _userRepository.AddUser(user, cancellationToken);
            var admin = new Admin
            {
                User = newUser,
                UserId = newUser.Id
                
            };
            var newAdmin = await _adminRepository.CraeteAdmin(admin, cancellationToken);
            if(newAdmin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin Created Succesfully",
                    Status = true

                };
            }
            return new BaseResponse
            {
                Message = "Admin Created Succesfully",
                Status = true

            };
           
        }

        public async Task<BaseResponse> DeleteAdmin(int id, CancellationToken cancellationToken)
        {
            var myAdmin = await _adminRepository.GetAdminById(id, cancellationToken);
            var delete = await _adminRepository.DeleteAdmin(myAdmin.Id, cancellationToken);
            if(delete.Succeeded)
            {
                return new BaseResponse
                {
                    Message = "Unable to delete Admin",
                    Status = false,
                };
            }
            return new BaseResponse
            {
                Message = "Admin Deleted Successfully",
                Status = true,
            };
        }

        public async Task<AdminResponseModel> GetAdminById(int id, CancellationToken cancellationToken)
        {
            var admin = await _adminRepository.GetAdminById(id, cancellationToken);
            if (admin == null)
            {
                return new AdminResponseModel
                {
                    Message = "Could not find admin",
                    Status = false
                };
            }
            return new AdminResponseModel
            {
                Data = new AdminDTO
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    Password = admin.Password
                },
                Message = "Admin successfully found",
                Status = true
            };
        }

        public async Task<ListOfAdminResponseModel> GetAllAdmins(CancellationToken cancellationToken)
        {
            var admins = await _adminRepository.GetAllAdmin(cancellationToken);
            return new ListOfAdminResponseModel
            {
                Data = admins.Select(ad => new AdminDTO
                {
                    FirstName = ad.FirstName,
                    LastName = ad.LastName,
                    Email = ad.Email,
                    Password = ad.Password
                }).ToList(),
                Message = "succesful",
                Status = true
            };
        }

        public Task<BaseResponse> UpdateAdmin(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
