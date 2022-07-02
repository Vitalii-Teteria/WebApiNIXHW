using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NIX_HW.Models;

namespace NIX_HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalsController : ControllerBase
    {
        private readonly JournalDBContext _context;

        public JournalsController(JournalDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Journals>> Post(Journals journals)
        {
            if (_context.JournalDBContexts != null)
            {
                _context.JournalDBContexts.Add(journals);
                await _context.SaveChangesAsync();

            }
            else
                return BadRequest("It`s dont work");

            return CreatedAtAction("GetJournals", new { id = journals.Id }, journals);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journals>>> GetJournals()
        {
          if (_context.JournalDBContexts != null)
          {
                return await _context.JournalDBContexts.ToListAsync();
          }
          else 
                return NotFound();       
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Journals>> GetJournals(Guid id)
        {
          if (_context.JournalDBContexts == null)
          {
              return NotFound();
          }
            var journals = await _context.JournalDBContexts.FindAsync(id);

            if (journals == null)
            {
                return NotFound();
            }

            return journals;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournals(Guid id)
        {
            if (_context.JournalDBContexts == null)
            {
                return NotFound();
            }
            var journals = await _context.JournalDBContexts.FindAsync(id);
            if (journals == null)
            {
                return NotFound();
            }

            _context.JournalDBContexts.Remove(journals);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpPatch("{id}")]
        //public async Task<IActionResult> PatchJournal(Guid id, Journals patchJournals)
        //{
            
        //}
    }
}
