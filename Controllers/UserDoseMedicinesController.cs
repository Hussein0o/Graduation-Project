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
    public class UserDoseMedicinesController : ControllerBase
    {
        private readonly medicalContext _context;

        public UserDoseMedicinesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/UserDoseMedicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDoseMedicine>>> GetUserDoseMedicine()
        {
            return await _context.UserDoseMedicine.ToListAsync();
        }

        // GET: api/UserDoseMedicines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDoseMedicine>> GetUserDoseMedicine(int id)
        {
            var userDoseMedicine = await _context.UserDoseMedicine.FindAsync(id);

            if (userDoseMedicine == null)
            {
                return NotFound();
            }

            return userDoseMedicine;
        }

        // PUT: api/UserDoseMedicines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDoseMedicine(int id, UserDoseMedicine userDoseMedicine)
        {
            if (id != userDoseMedicine.Dose_Code)
            {
                return BadRequest();
            }

            _context.Entry(userDoseMedicine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDoseMedicineExists(id))
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

        // POST: api/UserDoseMedicines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDoseMedicine>> PostUserDoseMedicine(UserDoseMedicine userDoseMedicine)
        {
            _context.UserDoseMedicine.Add(userDoseMedicine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDoseMedicine", new { id = userDoseMedicine.Dose_Code }, userDoseMedicine);
        }

        // DELETE: api/UserDoseMedicines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDoseMedicine>> DeleteUserDoseMedicine(int id)
        {
            var userDoseMedicine = await _context.UserDoseMedicine.FindAsync(id);
            if (userDoseMedicine == null)
            {
                return NotFound();
            }

            _context.UserDoseMedicine.Remove(userDoseMedicine);
            await _context.SaveChangesAsync();

            return userDoseMedicine;
        }

        private bool UserDoseMedicineExists(int id)
        {
            return _context.UserDoseMedicine.Any(e => e.Dose_Code == id);
        }
    }
}
