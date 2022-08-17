using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Contexts;
using QuizApp.DTO;
using QuizApp.Entities;
using QuizApp.Interface;

namespace QuizApp.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;
        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IdentityResult> CraeteAdmin(Admin admin, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Admins.AddAsync(admin, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAdmin(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admin = await _context.Admins.FindAsync(id);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<AdminDTO> GetAdminById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if(id == 0)
            {
                throw new ArgumentNullException();
            }
            var admin = await _context.Admins.Include(ad => ad.User).SingleOrDefaultAsync(ad => ad.Id == id, cancellationToken);
            if(admin == null)
            {
                throw new ArgumentNullException();
            }
            return new AdminDTO
            {
                Id = admin.Id,
                FirstName = admin.User.FirstName,
                LastName = admin.User.LastName,
                Email = admin.User.Email,
                Password = admin.User.Password

            };
        }

        public async Task<IList<AdminDTO>> GetAllAdmin(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var admins = await _context.Admins.Include(ad => ad.User).ToListAsync(cancellationToken);
            return admins.Select(admin => new AdminDTO
            {
                FirstName = admin.User.FirstName,
                LastName = admin.User.LastName,
                Email = admin.User.Email,
                Id = admin.Id,
                Password = admin.User.Password 
            }).ToList();
        }

        public async Task<IdentityResult> UpdateAdmin(Admin admin, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }
    }
    
}
