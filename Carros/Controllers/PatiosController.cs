using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carros.Data;
using Carros.models;

namespace Carros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatiosController : ControllerBase
    {
        private readonly CarrosContext _context;

        public PatiosController(CarrosContext context)
        {
            _context = context;
        }

        // GET: api/Patios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetPatio()
        {
            return await _context.Patio.ToListAsync();
        }

        // GET: api/Patios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetPatio(int id)
        {
            var patio = await _context.Patio.FindAsync(id);

            if (patio == null)
            {
                return NotFound();
            }

            return patio;
        }

        // PUT: api/Patios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatio(int id, Patio patio)
        {
            if (id != patio.PatioId)
            {
                return BadRequest();
            }

            _context.Entry(patio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatioExists(id))
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

        // POST: api/Patios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patio>> PostPatio(Patio patio)
        {
            _context.Patio.Add(patio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatio", new { id = patio.PatioId }, patio);
        }

        // DELETE: api/Patios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatio(int id)
        {
            var patio = await _context.Patio.FindAsync(id);
            if (patio == null)
            {
                return NotFound();
            }

            _context.Patio.Remove(patio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatioExists(int id)
        {
            return _context.Patio.Any(e => e.PatioId == id);
        }
    }
}
