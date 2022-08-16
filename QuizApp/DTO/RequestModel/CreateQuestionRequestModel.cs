namespace QuizApp.DTO.RequestModel
{
    public class CreateQuestionRequestModel
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }

    }
}
