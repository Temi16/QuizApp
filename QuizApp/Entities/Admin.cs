using QuizApp.Contracts;

namespace QuizApp.Entities
{
    public class Admin : AuditableEntity
    {
        public int UserId { get; set; }
    }
}
