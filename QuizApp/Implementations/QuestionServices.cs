using QuizApp.Contexts;
using QuizApp.DTO;
using QuizApp.DTO.RequestModel;
using QuizApp.Entities;
using QuizApp.Interface.IRepository;
using QuizApp.Interface.IService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Implementations
{
    public class QuestionServices : IQuestionServices
    {
        private readonly ApplicationContext _context;
        public IQuestionRepository _questionRepository;
        public ICategoryRepository _categoryRepository;
        public QuestionServices(ApplicationContext context, IQuestionRepository questionRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<QuestionDTO> AddQuestion(CreateQuestionRequestModel question, CancellationToken cancellationToken)
        {
            if (question == null)
            {
                throw new ArgumentNullException();
            }
            var newQuestion = new Question()
            {
                Description = question.Description,
                label = question.Answer,
                //Options = question.Options
                
            };
            await _questionRepository.AddQuestion(newQuestion, cancellationToken);
            var category = new Category()
            {
                Id = question.CategoryId,
            };
            await _categoryRepository.CreateCategory(category,cancellationToken);
            return new QuestionDTO()
            {
                Description = newQuestion.Description,
                Label = newQuestion.label,
            };
        }
    }
}
