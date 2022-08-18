using QuizApp.DTO;
using QuizApp.DTO.RequestModel;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Interface.IService
{
    public interface IQuestionServices
    {
        public Task<QuestionDTO>AddQuestion(CreateQuestionRequestModel question, CancellationToken cancellationToken);
    }
}
