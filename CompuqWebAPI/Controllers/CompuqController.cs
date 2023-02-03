using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompuqWebAPI.Models;

namespace CompuqWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompuqController : ControllerBase
    {
        private readonly CompuqContext _context;

        public CompuqController(CompuqContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {   
            if(customer.CustomerId == 0)
                return BadRequest();
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Customer customerData)
        {
            if (customerData == null || customerData.CustomerId == 0)
                return BadRequest();

            var customer = await _context.Customers.FindAsync(customerData.CustomerId);
            if (customer == null)
                return NotFound();
            customer.CustomerName = customerData.CustomerName;
            customer.PhoneNumber = customerData.PhoneNumber;
            customer.PhoneMake = customerData.PhoneMake;
            customer.PhoneMonthlypay = customerData.PhoneMonthlypay;
            customer.PhonePlanMonthlypay = customerData.PhonePlanMonthlypay;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = _context.Customers.FindAsync(id);
            if (customer.Result == null)
                return NotFound();
            _context.Customers.Remove(customer.Result);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
