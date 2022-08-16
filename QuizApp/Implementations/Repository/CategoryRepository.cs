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
using QuizApp.Interface.IRepository;

namespace QuizApp.Implementations.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IdentityResult> CreateCategory(Category category, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteCategory(Category category, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IList<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            return categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();
        }

        public async Task<CategoryDTO> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var category = await _context.Categories.SingleOrDefaultAsync(ca => ca.Id == id, cancellationToken);
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,

            };
        }

        public async Task<IdentityResult> UpdateCategory(Category category, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }
    }
}
