using QuizApp.DTO;
using QuizApp.DTO.ResponseModel;
using QuizApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using static QuizApp.DTO.RequestModel.CreateOptionRequestModel;

namespace QuizApp.Interface.IService
{
    public interface IOptionService
    {
        Task<BaseResponse> CreateOptionAsync(CreateOptionRequest option, CancellationToken cancellationToken);

        Task<BaseResponse> UpdateOptionAsync(int id, UpdateOptionRequest updateOption, CancellationToken cancellationToken);

        Task<BaseResponse> DeleteOptionAsync(int id, CancellationToken cancellationToken);

        Task<OptionsResponseModel> GetAllOptionAsync(CancellationToken cancellationToken);
    }
}
