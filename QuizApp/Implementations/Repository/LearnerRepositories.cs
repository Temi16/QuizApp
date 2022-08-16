using QuizApp.Contexts;
using QuizApp.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class LearnerRepositories : ILearnerRepository
{
    private readonly ApplicationContext _context;
    public LearnerRepositories(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateLearnerAsync(Learner learner)
    {
        await _context.Learners.AddAsync(learner);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditLearnerAsync(Learner learner)
    {

        _context.Learners.Update(learner);
       await _context.SaveChangesAsync();
        return true;
    }
  
    public  async Task<Learner> GetLearnerAsync(int id)
    {
        var learner = await _context.Learners.FindAsync(id);
        return learner;
    }

    public async Task<ICollection<Learner>> GetLearnersAsync()
    {
        var learners = await _context.Learners.Include(x => x.User).ToListAsync();
        return learners;
    }
}
