using QuizApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ILearnerRepository
{
    Task<bool> CreateLearnerAsync(Learner learner);
    Task<bool> EditLearnerAsync(Learner learner);
    Task<Learner> GetLearnerAsync(int id);
    Task<ICollection<Learner>> GetLearnersAsync();
    
}
