using BestLicenseAPI.Data;
using BestLicenseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestLicenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext dbContext;
        public CustomerController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await this.dbContext.Customers.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Customers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var dbCustomer = await dbContext.Customers.FindAsync(id);
            if (dbCustomer == null)
                return BadRequest("No customer found!");

            dbContext.Customers.Remove(dbCustomer);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Customers.ToListAsync());
        }
    }
}
