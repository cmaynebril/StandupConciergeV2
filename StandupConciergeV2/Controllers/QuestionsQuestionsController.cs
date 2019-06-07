using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StandupConciergeV2.Models;

namespace StandupConciergeV2.Controllers
{
    public class QuestionsQuestionsController : Controller
    {
        private readonly StandupConciergeContext _context;

        public QuestionsQuestionsController(StandupConciergeContext context)
        {
            _context = context;
        }

        // GET: QuestionsQuestions
        public async Task<IActionResult> Index()
        {
            var standupConciergeContext = _context.QuestionsQuestion.Include(q => q.Question);
            return View(await standupConciergeContext.ToListAsync());
        }

        // GET: QuestionsQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsQuestion = await _context.QuestionsQuestion
                .Include(q => q.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionsQuestion == null)
            {
                return NotFound();
            }

            return View(questionsQuestion);
        }

        // GET: QuestionsQuestions/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
            return View();
        }

        // POST: QuestionsQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuestionId,Questions")] QuestionsQuestion questionsQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionsQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", questionsQuestion.QuestionId);
            return View(questionsQuestion);
        }

        // GET: QuestionsQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsQuestion = await _context.QuestionsQuestion.FindAsync(id);
            if (questionsQuestion == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", questionsQuestion.QuestionId);
            return View(questionsQuestion);
        }

        // POST: QuestionsQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionId,Questions")] QuestionsQuestion questionsQuestion)
        {
            if (id != questionsQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionsQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionsQuestionExists(questionsQuestion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", questionsQuestion.QuestionId);
            return View(questionsQuestion);
        }

        // GET: QuestionsQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsQuestion = await _context.QuestionsQuestion
                .Include(q => q.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionsQuestion == null)
            {
                return NotFound();
            }

            return View(questionsQuestion);
        }

        // POST: QuestionsQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionsQuestion = await _context.QuestionsQuestion.FindAsync(id);
            _context.QuestionsQuestion.Remove(questionsQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionsQuestionExists(int id)
        {
            return _context.QuestionsQuestion.Any(e => e.Id == id);
        }
    }
}
