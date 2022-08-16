using QuizApp.Contexts;
using QuizApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class LearnerRepositories : ILearnerRepository
{
    private readonly ApplicationContext _context;
    public LearnerRepositories(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateLearner(Learner learner)
    {
        await _context.Learners.AddAsync(learner);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditLearner(Learner learner)
    {

       await _context.Learners.UpdateAsync(learner);
       await _context.SaveChangesAsync();
        return true;
    }
  
    public  async Task<Learner> GetLearner(int id)
    {
        var learner = await _context.Learners.Find(id);
        return learner;
    }

    public async Task<IList<Learner>> GetLearners()
    {
        var learners = await _context.Learners.ToList();
        return learners;
    }
}
