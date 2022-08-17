using System.Collections.Generic;

namespace QuizApp.DTO.ResponseModel
{
    public class AdminResponseModel : BaseResponse
    {
        public AdminDTO Data { get; set; }
    }
    public class ListOfAdminResponseModel : BaseResponse
    {
        public IList<AdminDTO> Data { get; set; }
    }
    
}
