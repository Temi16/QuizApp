﻿using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizApp.Contexts;
using QuizApp.Entities.Identity;
using QuizApp.Interface.Identity;
using System;

namespace QuizApp.Implementations.Identity
{
    public class UserRepository:IUserRepository
    {
        public ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ICollection<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var users = await _context.Users.Include(u => u.Id).ToListAsync();
            return users;

        }

       

        public async Task<User> GetUserAsync(int id,CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if(id == 0)
            {
                throw new ArgumentNullException();
            }
            var user = await _context.Users.FirstOrDefaultAsync(op => op.Id == id,cancellationToken);
            if (user == null)
            {
                return null;
            }
            return user;
            
        }

     
    }
}
