using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandupConciergeV2.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime? date { get; set; }
        public DateTime? time { get; set; }
        public string frequency { get; set; }
        public string day { get; set; }

        public IEnumerable<Question> Questions { get; set; }
    }
}
