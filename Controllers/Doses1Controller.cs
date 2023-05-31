using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuroraAPI.Models;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Doses1Controller : ControllerBase
    {
        private readonly medicalContext _context;

        public Doses1Controller(medicalContext context)
        {
            _context = context;
        }

        // GET: api/Doses1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doses1>>> GetDoses1()
        {
            return await _context.Doses1.ToListAsync();
        }

        // GET: api/Doses1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doses1>> GetDoses1(int id)
        {
            var doses1 = await _context.Doses1.FindAsync(id);

            if (doses1 == null)
            {
                return NotFound();
            }

            return doses1;
        }

        // PUT: api/Doses1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoses1(int id, Doses1 doses1)
        {
            if (id != doses1.Dose_Code)
            {
                return BadRequest();
            }

            _context.Entry(doses1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Doses1Exists(id))
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

        // POST: api/Doses1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Doses1>> PostDoses1(Doses1 doses1)
        {
            _context.Doses1.Add(doses1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoses1", new { id = doses1.Dose_Code }, doses1);
        }

        // DELETE: api/Doses1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doses1>> DeleteDoses1(int id)
        {
            var doses1 = await _context.Doses1.FindAsync(id);
            if (doses1 == null)
            {
                return NotFound();
            }

            _context.Doses1.Remove(doses1);
            await _context.SaveChangesAsync();

            return doses1;
        }

        private bool Doses1Exists(int id)
        {
            return _context.Doses1.Any(e => e.Dose_Code == id);
        }
    }
}
