using QuizApp.Contracts;

namespace QuizApp.Entities
{
    public class Option : BaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public string Label { get; set; }
    }
}
