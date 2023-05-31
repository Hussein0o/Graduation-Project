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
    public class MedicinesController : ControllerBase
    {
        private readonly medicalContext _context;

        public MedicinesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicine()
        {
            return await _context.Medicine.ToListAsync();
        }

        // GET: api/Medicines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetMedicine(int id)
        {
            var medicine = await _context.Medicine.FindAsync(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return medicine;
        }

        // PUT: api/Medicines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicine(int id, Medicine medicine)
        {
            if (id != medicine.Medicine_Code)
            {
                return BadRequest();
            }

            _context.Entry(medicine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
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

        // POST: api/Medicines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            _context.Medicine.Add(medicine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicine", new { id = medicine.Medicine_Code }, medicine);
        }

        // DELETE: api/Medicines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medicine>> DeleteMedicine(int id)
        {
            var medicine = await _context.Medicine.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            _context.Medicine.Remove(medicine);
            await _context.SaveChangesAsync();

            return medicine;
        }

        private bool MedicineExists(int id)
        {
            return _context.Medicine.Any(e => e.Medicine_Code == id);
        }
    }
}
