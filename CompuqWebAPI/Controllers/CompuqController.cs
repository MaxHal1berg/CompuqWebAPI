using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompuqWebAPI.Models;

namespace CompuqWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompuqController : ControllerBase
    {
        private readonly CompuqDBContext _context;

        public CompuqController(CompuqDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Compuq>> Get()
        {
            return await _context.Compuqs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var compuq = await _context.Compuqs.FirstOrDefaultAsync(m => m.customer_id == id);
            if (compuq == null)
                return NotFound();
            return Ok(compuq);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Compuq compuq)
        {
            _context.Add(compuq);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Compuq compuqData)
        {
            if (compuqData == null || compuqData.customer_id == 0)
                return BadRequest();

            var compuq = await _context.Compuqs.FindAsync(compuqData.customer_id);
            if (compuq == null)
                return NotFound();
            compuq.customer_name = compuqData.customer_name;
            compuq.phone_number = compuqData.phone_number;
            compuq.phone_make = compuqData.phone_make;
            compuq.phone_monthlypay = compuqData.phone_monthlypay;
            compuq.phone_plan_monthlypay = compuqData.phone_plan_monthlypay;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 1)
                return BadRequest();
            var compuq = _context.Compuqs.FindAsync(id);
            if (compuq == null)
                return NotFound();
            _context.Compuqs.Remove(compuq);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
