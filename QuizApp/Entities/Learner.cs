﻿using QuizApp.Contracts;
using QuizApp.Entities.Identity;

namespace QuizApp.Entities
{
    public class Learner : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
