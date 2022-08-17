using Microsoft.AspNetCore.Identity;
using QuizApp.Entities.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Interface.Identity
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        public Task<User> GetUserAsync(int id, CancellationToken cancellationToken);
        public Task<User> AddUser(User user, CancellationToken cancellationToken);
    }
}

