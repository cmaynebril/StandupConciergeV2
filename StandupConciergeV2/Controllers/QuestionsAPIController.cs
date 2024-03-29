﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandupConciergeV2.Models;

namespace StandupConciergeV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsAPIController : ControllerBase
    {
        private readonly StandupConciergeContext _context;

        public QuestionsAPIController(StandupConciergeContext context)
        {
            _context = context;
        }

        // GET: api/QuestionsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var result = await (from a in _context.Questions
                                select new
                                {
                                    a.Id,
                                    Question = a.QuestionsQuestion.Where(x => x.QuestionId == a.Id)
                                    .Select(b => b.Questions
                                    ),
                                    a.ScheduleId
                                }).ToListAsync();
            return Ok(result);
        }

        // GET: api/QuestionsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var result = await (from a in _context.Questions
                                where a.Id == id
                                select new
                                {
                                    a.Id,
                                    QuestionsQuestion = a.QuestionsQuestion.Where(x => x.QuestionId == a.Id)
                                    .Select(b => b.Questions
                                    ),
                                    a.ScheduleId
                                }).ToListAsync();
            return Ok(result);
        }

        // PUT: api/QuestionsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuestionsAPI
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // DELETE: api/QuestionsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Question>> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return question;
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
