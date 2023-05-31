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
    public class ContactPhonesController : ControllerBase
    {
        private readonly medicalContext _context;

        public ContactPhonesController(medicalContext context)
        {
            _context = context;
        }

        // GET: api/ContactPhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactPhone>>> GetContactPhone()
        {
            return await _context.ContactPhone.ToListAsync();
        }

        // GET: api/ContactPhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPhone>> GetContactPhone(int id)
        {
            var contactPhone = await _context.ContactPhone.FindAsync(id);

            if (contactPhone == null)
            {
                return NotFound();
            }

            return contactPhone;
        }

        // PUT: api/ContactPhones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactPhone(int id, ContactPhone contactPhone)
        {
            if (id != contactPhone.Contact_Code)
            {
                return BadRequest();
            }

            _context.Entry(contactPhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactPhoneExists(id))
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

        // POST: api/ContactPhones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContactPhone>> PostContactPhone(ContactPhone contactPhone)
        {
            _context.ContactPhone.Add(contactPhone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactPhone", new { id = contactPhone.Contact_Code }, contactPhone);
        }

        // DELETE: api/ContactPhones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactPhone>> DeleteContactPhone(int id)
        {
            var contactPhone = await _context.ContactPhone.FindAsync(id);
            if (contactPhone == null)
            {
                return NotFound();
            }

            _context.ContactPhone.Remove(contactPhone);
            await _context.SaveChangesAsync();

            return contactPhone;
        }

        private bool ContactPhoneExists(int id)
        {
            return _context.ContactPhone.Any(e => e.Contact_Code == id);
        }
    }
}
