using QuizApp.Entities;
using System.Collections.Generic;

namespace QuizApp.DTO.RequestModel
{
    public class CreateQuestionRequestModel
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        //public ICollection<Option> Options { get; set; }

    }
}
