using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Contexts;
using QuizApp.Entities.Identity;
using QuizApp.Interface.Identity;
namespace QuizApp.Implementations.Identity
{
    public class UserRepository:IUserRepository
    {
        public ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ICollection<User>> GetAllUserAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var users = await _context.Users.Include(op => op.UserRole).ToListAsync(cancellationToken);
            return users;

        }
        public async Task<User> GetUserAsync(int id,CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if(id == 0)
            {
                throw new ArgumentNullException();
            }
            var user= _context.Users.FirstOrDefault(op => op.Id == id,cancellationToken);
            if (user == null)
            {
                return null;
            }
            
        }
    }
}
