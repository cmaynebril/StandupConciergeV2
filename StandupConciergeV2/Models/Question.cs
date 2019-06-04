using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandupConciergeV2.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        
        public IEnumerable<QuestionsQuestion> QuestionsQuestion { get; set; }

    }
}
