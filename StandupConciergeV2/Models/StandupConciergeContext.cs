using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StandupConciergeV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StandupConciergeV2.Models
{
    public class StandupConciergeContext : IdentityDbContext<User, UserRole, int>
    {
        public StandupConciergeContext(DbContextOptions<StandupConciergeContext> options)
         : base(options)
        {
        }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StandupConciergeV2.Models.QuestionsQuestion> QuestionsQuestion { get; set; }
    }
    
}
