using QuizApp.Contracts;

namespace QuizApp.Entities
{
    public class Learner : AuditableEntity
    {
        public int UserId { get; set; }
    }
}
