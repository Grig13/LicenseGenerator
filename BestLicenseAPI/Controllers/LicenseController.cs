using BestLicenseAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using BestLicenseAPI.Models;
using Portable.Licensing;
using System.Text;

namespace BestLicenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly DataContext dbContext;
        private readonly Models.Customer customer;
        private readonly Product product;
        public LicenseController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<System.ComponentModel.License>>> GetLicenses()
        {
            return Ok(await this.dbContext.Licenses.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<System.ComponentModel.License>>> CreateLicense(Models.License licenseAdd)
        {
            var license = Portable.Licensing.License.New()
                .WithUniqueIdentifier(Guid.NewGuid())
                .As(LicenseType.Trial)
                .ExpiresAt(DateTime.Now.AddMinutes(1))
                .WithMaximumUtilization(1)
                .WithProductFeatures(new Dictionary<string, string>
                {
                    {"Product name: ", licenseAdd.Product.Name }
                })
                .LicensedTo(licenseAdd.Customer.Name, licenseAdd.Customer.Email)
                .CreateAndSignWithPrivateKey(licenseAdd.Product.KeyPair, "test");

            licenseAdd.Id = Guid.NewGuid();
            licenseAdd.LicenseContent = license.GetHashCode().ToString();
            System.IO.File.WriteAllText("License.lic", license.ToString(), Encoding.UTF8);
            await this.dbContext.Licenses.AddAsync(licenseAdd);
            await this.dbContext.SaveChangesAsync();
            return Ok(await dbContext.Licenses.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<System.ComponentModel.License>>> DeleteLicense(int id)
        {
            var dbLicense = await dbContext.Licenses.FindAsync(id);
            if (dbLicense == null)
                return BadRequest("No license found!");

            dbContext.Licenses.Remove(dbLicense);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Licenses.ToListAsync());
        }

    }
}
