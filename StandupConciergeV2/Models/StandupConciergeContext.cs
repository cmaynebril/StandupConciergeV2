using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandupConciergeV2.Models
{
    public class StandupConciergeContext : DbContext
    {
        public StandupConciergeContext(DbContextOptions<StandupConciergeContext> options)
         : base(options)
        {
        }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<User> Users { get; set; }
    }
    
}
