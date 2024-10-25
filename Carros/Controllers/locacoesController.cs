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
    public class locacoesController : ControllerBase
    {
        private readonly CarrosContext _context;

        public locacoesController(CarrosContext context)
        {
            _context = context;
        }

        // GET: api/locacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<locacoes>>> Getlocacoes()
        {
            return await _context.locacoes.ToListAsync();
        }

        // GET: api/locacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<locacoes>> Getlocacoes(Guid id)
        {
            var locacoes = await _context.locacoes.FindAsync(id);

            if (locacoes == null)
            {
                return NotFound();
            }

            return locacoes;
        }

        // PUT: api/locacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlocacoes(Guid id, locacoes locacoes)
        {
            if (id != locacoes.id)
            {
                return BadRequest();
            }

            _context.Entry(locacoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!locacoesExists(id))
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

        // POST: api/locacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<locacoes>> Postlocacoes(locacoes locacoes)
        {
            _context.locacoes.Add(locacoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlocacoes", new { id = locacoes.id }, locacoes);
        }

        // DELETE: api/locacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelocacoes(Guid id)
        {
            var locacoes = await _context.locacoes.FindAsync(id);
            if (locacoes == null)
            {
                return NotFound();
            }

            _context.locacoes.Remove(locacoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool locacoesExists(Guid id)
        {
            return _context.locacoes.Any(e => e.id == id);
        }
    }
}
