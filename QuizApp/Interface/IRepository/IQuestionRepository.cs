using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuizApp.DTO;
using QuizApp.Entities;

namespace QuizApp.Interface.IRepository
{
    public interface IQuestionRepository
    {
        public Task<IdentityResult> AddQuestion(Question question, CancellationToken cancellationToken);
        public Task<IdentityResult> UpdateQuestion(Question question, CancellationToken cancellationToken);
        public Task<IdentityResult> DeleteQuestion(Question question, CancellationToken cancellationToken);
        public Task<IList<QuestionDTO>> GetAllQuestions(CancellationToken cancellationToken);
        public Task<QuestionDTO> GetQuestionById(int id, CancellationToken cancellationToken);
    }
}
