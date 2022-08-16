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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationContext _context;
        public QuestionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IdentityResult> AddQuestion(Question question, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _context.Questions.AddAsync(question, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteQuestion(Question question, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IList<QuestionDTO>> GetAllQuestions(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var questions = await _context.Questions.ToListAsync(cancellationToken);
            return questions.Select(question => new QuestionDTO
            {
                Id = question.Id,
                Description = question.Description,
                Label = question.label
                
            }).ToList();
        }

        public async Task<QuestionDTO> GetQuestionById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == id, cancellationToken);
            if (question == null)
            {
                throw new ArgumentNullException();
            }
            return new QuestionDTO
            {
                Id = question.Id,
                Description = question.Description,
                Label = question.label
            };
        }

        public async Task<IdentityResult> UpdateQuestion(Question question, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _context.Questions.Update(question);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }
    }
}
