﻿using QuizApp.Contracts;
using System.Collections.Generic;

namespace QuizApp.Entities.Identity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<UserRole> UserRole = new HashSet<UserRole>();
    }
}