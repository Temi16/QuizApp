using Microsoft.AspNetCore.Identity;
using QuizApp.DTO;
using QuizApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Interface.IRepository
{
    public interface IOptionRepository
    {
        Task<IdentityResult> CreateOptionAsync(Option option, CancellationToken cancellationToken);

        Task<IdentityResult> UpdateOptionAsync(Option option, CancellationToken cancellationToken);

        Task<IList<OptionDTO>> GetAllOptionsAsync(CancellationToken cancellationToken);

        Task<IdentityResult> DeleteOptionAsync(Option option, CancellationToken cancellationToken);

        Task<OptionDTO> GetByExpressionAsync(Expression<Func<Option, bool>> expression);
    }
}
