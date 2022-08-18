using QuizApp.DTO;
using QuizApp.DTO.ResponseModel;
using QuizApp.Entities;
using QuizApp.Interface.IRepository;
using QuizApp.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using static QuizApp.DTO.RequestModel.CreateOptionRequestModel;

namespace QuizApp.Implementations.Service
{
    public class OptionService:IOptionService
    {
        private readonly IOptionRepository _optionRepository;

        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public async Task<BaseResponse> CreateOptionAsync(CreateOptionRequest optionRequest, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var option = new Option
            { 
                Description = optionRequest.Description,

                Label = optionRequest.Label,

                IsCorrect = true
            };

            var op = await _optionRepository.CreateOptionAsync(option, cancellationToken);

            if(op == null)
            {
                return null;
            }

            var reponse = new BaseResponse 
            { 
                Message = "Successfully Created",

                Status = true
            };

            return reponse;
        }
        public async Task<BaseResponse> UpdateOptionAsync(int id, UpdateOptionRequest optionRequest, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var op = await _optionRepository.GetByExpressionAsync(op => op.Id == id);

            if (op == null)
            {
                return null;
            }

            op.Description = optionRequest.Description;

            op.Label = optionRequest.Label;

            await _optionRepository.UpdateOptionAsync(op, cancellationToken);

            var response = new BaseResponse 
            {
                Message ="Update Successful",

                Status = true
            };
         
            return response;
        }

        public async Task<BaseResponse> DeleteOptionAsync(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var op = await _optionRepository.GetByExpressionAsync(op => op.Id == id);

            if(op == null)
            {
                return null;
            }

            await _optionRepository.DeleteOptionAsync(op, cancellationToken);

            var response = new BaseResponse 
            {
               Message = "Delete Successful",

               Status = true
            };

            return response;
        }
        
        public async Task<OptionsResponseModel> GetAllOptionAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

           var e =  await _optionRepository.GetAllOptionsAsync(cancellationToken);

            return new OptionsResponseModel
            {
                OptionDTOs = e.Select(s => new OptionDTO
                {
                    Description = s.Description,

                    Label = s.Label

                }).ToList()
            };

         
        }

        public async Task<Option> GetById(int id, CancellationToken cacellationToken)
        {
            var op = await _optionRepository.GetByExpressionAsync(op => op.Id == id);

            if(op == null)
            {
                return null;
            }

            return new Option 
            { 
                Description = op.Description,

                Label = op.Label
            };
        }

        public async Task<Option> GetByLabel(string description, CancellationToken cancellationToken)
        {
            var op = await _optionRepository.GetByExpressionAsync(op => op.Description == description);

            if(op == null)
            {
                return null;
            }

            return new Option
            {56
                Description = op.Description,

                Label = op.Label
            };
        }

        public async Task<Option> GetByDescription(string label, CancellationToken cancellationToken)
        {
            var op = await _optionRepository.GetByExpressionAsync(op => op.Label == label);

            if(op == null)
            {
                return null;
            }

            return new Option
            {
                Description = op.Description,

                Label = op.Label
            };
        }
    }
}
