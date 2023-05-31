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
    public class EcsController : ControllerBase
    {
        private readonly medicalContext _context;

        public EcsController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/Ecs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ec>>> GetEc()
        {
            return await _context.Ec.ToListAsync();
        }

        // GET: api/Ecs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ec>> GetEc(int id)
        {
            var ec = await _context.Ec.FindAsync(id);

            if (ec == null)
            {
                return NotFound();
            }

            return ec;
        }

        // PUT: api/Ecs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEc(int id, Ec ec)
        {
            if (id != ec.User_Id)
            {
                return BadRequest();
            }

            _context.Entry(ec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EcExists(id))
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

        // POST: api/Ecs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ec>> PostEc(Ec ec)
        {
            _context.Ec.Add(ec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEc", new { id = ec.User_Id }, ec);
        }

        // DELETE: api/Ecs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ec>> DeleteEc(int id)
        {
            var ec = await _context.Ec.FindAsync(id);
            if (ec == null)
            {
                return NotFound();
            }

            _context.Ec.Remove(ec);
            await _context.SaveChangesAsync();

            return ec;
        }

        private bool EcExists(int id)
        {
            return _context.Ec.Any(e => e.User_Id == id);
        }
    }
}
