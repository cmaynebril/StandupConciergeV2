using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StandUpConceirge.Models
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public DateTime? date { get; set; }
        public DateTime? time { get; set; }
        public string frequency { get; set; }
        public string day { get; set; }
        public int? ScheduleId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        [Required]
        public string WelcomeMsg { get; set; }
        [NotMapped]
        public string[] Respondents { get; set; }
        [NotMapped]
        public string[] Question { get; set; }
               
    }
}
