using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StandUpConceirge.Models;
using StandupConciergeV2.Models;

namespace StandupConciergeV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly StandupConciergeContext _context;

        public HomeController(StandupConciergeContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            //var respondentsList = _context.Users.ToList();
            //var dropdownRespondentsList = new List<SelectListItem>();
            //foreach (var respondents in respondentsList)
            //{
            //    dropdownRespondentsList.Add(new SelectListItem { Value = respondents.Id.ToString(), Text = respondents.Name.ToString() });
            //}
            //ViewBag.RespondentsList = dropdownRespondentsList;

            //return View(await _context.BotSchedule.ToListAsync());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Scheduling()
        {
            var respondentsList = _context.Users.ToList();
            var dropdownRespondentsList = new List<SelectListItem>();
            foreach (var users in respondentsList)
            {
                dropdownRespondentsList.Add(new SelectListItem { Value = users.UserName.ToString(), Text = users.UserName.ToString() });
            }
            ViewBag.respondentsList = dropdownRespondentsList;
            return View();
        }
        // GET: BotSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BotSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleViewModel ScheduleViewModel)
        {
            if (ModelState.IsValid)
            {

                for (int j = 0; j < ScheduleViewModel.Respondents.Length; j++)
                {
                    Schedule sched = new Schedule();
                    sched.Id = ScheduleViewModel.Id;
                    sched.date = ScheduleViewModel.date;
                    sched.time = ScheduleViewModel.time;
                    sched.day = "Monday";

                    //sched.Monday = ScheduleViewModel.Monday.ToString().Substring(0, 1);
                    //sched.Tuesday = ScheduleViewModel.Tuesday.ToString().Substring(0, 1);
                    //sched.Wednesday = ScheduleViewModel.Monday.ToString().Substring(0, 1);
                    //sched.Thursday = ScheduleViewModel.Thursday.ToString().Substring(0, 1);
                    //sched.Friday = ScheduleViewModel.Friday.ToString().Substring(0, 1);
                    //sched.Saturday = ScheduleViewModel.Saturday.ToString().Substring(0, 1);
                    //sched.Sunday = ScheduleViewModel.Sunday.ToString().Substring(0, 1);

                    //sched.Creator = "Chris";
                    //sched.ScheduleId = schedID;

                    sched.frequency = ScheduleViewModel.frequency;
                    sched.day = ScheduleViewModel.day;
                    //sched.Respondents = ScheduleViewModel.Respondents[j];

                    _context.Add(sched);
                    await _context.SaveChangesAsync();
                }

                var schedID = _context.Schedules.LastOrDefault();

                Question quest = new Question();
                quest.ScheduleId = schedID.Id;

                _context.Add(quest);
                await _context.SaveChangesAsync();

                var questionID = _context.Questions.LastOrDefault();
                for (int i = 0; i < ScheduleViewModel.Question.Length; i++)
                {
                    QuestionsQuestion question = new QuestionsQuestion();
                    question.QuestionId = questionID.Id;
                    question.Questions = ScheduleViewModel.Question[i];

                    _context.Add(question);
                    await _context.SaveChangesAsync();


                }

                //var SurveyId = _context.BotSchedule.ToList().LastOrDefault();



                return RedirectToAction(nameof(Scheduling));
            }
            return View(ScheduleViewModel);
        }
    }
}
