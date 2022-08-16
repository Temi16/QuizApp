using QuizApp.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Interface.Identity
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAllUsersync();
        public Task<User> GetUserAsync();
    }
}

