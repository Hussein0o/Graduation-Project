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
    public class UserPhonesController : ControllerBase
    {
        private readonly medicalContext _context;

        public UserPhonesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/UserPhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPhone>>> GetUserPhone()
        {
            return await _context.UserPhone.ToListAsync();
        }

        // GET: api/UserPhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPhone>> GetUserPhone(int id)
        {
            var userPhone = await _context.UserPhone.FindAsync(id);

            if (userPhone == null)
            {
                return NotFound();
            }

            return userPhone;
        }

        // PUT: api/UserPhones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPhone(int id, UserPhone userPhone)
        {
            if (id != userPhone.User_Id)
            {
                return BadRequest();
            }

            _context.Entry(userPhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPhoneExists(id))
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

        // POST: api/UserPhones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserPhone>> PostUserPhone(UserPhone userPhone)
        {
            _context.UserPhone.Add(userPhone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPhone", new { id = userPhone.User_Id }, userPhone);
        }

        // DELETE: api/UserPhones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserPhone>> DeleteUserPhone(int id)
        {
            var userPhone = await _context.UserPhone.FindAsync(id);
            if (userPhone == null)
            {
                return NotFound();
            }

            _context.UserPhone.Remove(userPhone);
            await _context.SaveChangesAsync();

            return userPhone;
        }

        private bool UserPhoneExists(int id)
        {
            return _context.UserPhone.Any(e => e.User_Id == id);
        }
    }
}
