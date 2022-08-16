using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Contexts;
using QuizApp.DTO;
using QuizApp.Entities;
using QuizApp.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Implementations.Repository
{
    public class OptionRepository:IOptionRepository
    {
        private readonly ApplicationContext _context;

        public OptionRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<IdentityResult> CreateOptionAsync(Option option, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _context.Options.AddAsync(option);

            await _context.SaveChangesAsync();

            return IdentityResult.Success;

        }

        public async Task<IdentityResult> UpdateOptionAsync(Option option, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _context.Options.Update(option);

            await _context.SaveChangesAsync();

            return IdentityResult.Success;
        }


        public async Task<IdentityResult> DeleteOptionAsync (Option option, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

             _context.Options.Remove(option);

            await _context.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public async Task<IList<OptionDTO>> GetAllOptionsAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var options = await _context.Options.ToListAsync(cancellationToken);

            return options.Select(option => new OptionDTO
            {
                Id = option.Id,
                Description = option.Description,
                Label = option.Label
            }).ToList();
        }

        public async Task<OptionDTO> GetByExpressionAsync(Expression<Func<Option, bool>> expression)
        {
            var result = await _context.Options.FirstOrDefaultAsync(expression);
            return new OptionDTO
            {
                Id = result.Id,
                Description = result.Description,
                Label = result.Label,
            };
        }


    }
}
