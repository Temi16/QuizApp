using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuizApp.DTO;
using QuizApp.Entities;

namespace QuizApp.Interface.IRepository
{
    public interface ICategoryRepository
    {
        public Task<IdentityResult> CreateCategory(Category category, CancellationToken cancellationToken);
        public Task<IdentityResult> UpdateCategory(Category category, CancellationToken cancellationToken);
        public Task<IdentityResult> DeleteCategory(Category category, CancellationToken cancellationToken);
        public Task<CategoryDTO> GetCategoryById(int id, CancellationToken cancellationToken);
        public Task<IList<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken);
}
