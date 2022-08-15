using QuizApp.Contracts;
using System.Collections.Generic;

namespace QuizApp.Entities.Identity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRole = new HashSet<UserRole>();
    }
}
