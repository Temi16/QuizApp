using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.DTO.ResponseModel
{
    public class OptionResponseModel:BaseResponse
    {
        public OptionDTO OptionData { get; set; }

    }

    public class OptionsResponseModel : BaseResponse
    {
        public List<OptionDTO> OptionDTOs { get; set; }
    }
}
