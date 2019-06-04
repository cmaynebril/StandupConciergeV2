using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index()
        {
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
                dropdownRespondentsList.Add(new SelectListItem { Value = users.Name.ToString(), Text = users.Name.ToString() });
            }
            ViewBag.respondentsList = dropdownRespondentsList;
            return View();
        }
    }
}
