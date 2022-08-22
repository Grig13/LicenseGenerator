using BestLicenseAPI.Data;
using BestLicenseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestLicenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext dbContext;
        public string passPhrase = "test";
        public ProductController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await this.dbContext.Products.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Product>>> CreateProduct(Product product)
        {
            var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();
            var keyPair = keyGenerator.GenerateKeyPair();
            var privateKey = keyPair.ToEncryptedPrivateKeyString(passPhrase);
            var publicKey = keyPair.ToPublicKeyString();
            product.KeyPair = privateKey;
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Products.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var dbProduct = await dbContext.Products.FindAsync(id);
            if(dbProduct == null)
            {
                return BadRequest("No product found!");
            }

            dbContext.Products.Remove(dbProduct);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Products.ToListAsync());
        }
    }
}
