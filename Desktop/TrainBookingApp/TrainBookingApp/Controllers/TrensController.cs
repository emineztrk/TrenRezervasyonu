using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainBookingApp.Models;

namespace TrainBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrensController : ControllerBase
    {
        private readonly Context _context;

        public TrensController(Context context)
        {
            _context = context;
        }

        // GET: api/Trens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tren>>> GetTrens()
        {
          if (_context.Trens == null)
          {
              return NotFound();
          }
            return await _context.Trens.ToListAsync();
        }

        // GET: api/Trens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tren>> GetTren(long id)
        {
          if (_context.Trens == null)
          {
              return NotFound();
          }
            var tren = await _context.Trens.FindAsync(id);

            if (tren == null)
            {
                return NotFound();
            }

            return tren;
        }

        // PUT: api/Trens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTren(long id, Tren tren)
        {
            if (id != tren.Id)
            {
                return BadRequest();
            }

            _context.Entry(tren).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrenExists(id))
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

        // POST: api/Trens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tren>> PostTren(Tren tren)
        {
          if (_context.Trens == null)
          {
              return Problem("Entity set 'Context.Trens'  is null.");
          }
            _context.Trens.Add(tren);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTren", new { id = tren.Id }, tren);
            return CreatedAtAction(nameof(GetTren), new { id = tren.Id }, tren);
        }

        // DELETE: api/Trens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTren(long id)
        {
            if (_context.Trens == null)
            {
                return NotFound();
            }
            var tren = await _context.Trens.FindAsync(id);
            if (tren == null)
            {
                return NotFound();
            }

            _context.Trens.Remove(tren);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrenExists(long id)
        {
            return (_context.Trens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
