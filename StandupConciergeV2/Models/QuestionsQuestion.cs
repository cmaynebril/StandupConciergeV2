using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandupConciergeV2.Models
{
    public class QuestionsQuestion
    {
        
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Questions { get; set; }

        public Question Question { get; set; }

    }
}
