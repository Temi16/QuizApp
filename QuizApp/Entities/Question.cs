using System.Collections.Generic;
using QuizApp.Contracts;

namespace QuizApp.Entities
{
    public class Question : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string label { get; set; }

        public ICollection<Option> Options { get; set; }
        
    }
}
