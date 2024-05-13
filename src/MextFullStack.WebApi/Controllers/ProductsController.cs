using MextFullStack.Domain.Dtos;
using MextFullStack.Domain.Entities;
using MextFullStack.Persistence.Contexts;
using MextFullStack.WebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var productDtos = await _dbContext
                .Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Select(p => ProductGetAllDto.FromProduct(p))
                .ToListAsync(cancellationToken);

            return Ok(productDtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _dbContext
                .Products
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (product == null)
                return NotFound("Aradaginiz urun sistemde bulunamadi.");



            var productDto = ProductGetByIdDto.FromProduct(product);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            if (product.Name.Length <= 2)
                return BadRequest("Urun ismi en az 2 karakter olmalidir.");

            if (product.Price <= 0)
                return BadRequest("Urun fiyati sifirdan buyuk olmalidir.");


            if (await _dbContext.Products.AnyAsync(p => p.Name.ToLowerInvariant() == product.Name.ToLowerInvariant(), cancellationToken))
                return BadRequest("Bu isimde bir urun zaten mevcut.");

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok(product.Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, ProductEditDto productEditDto, CancellationToken cancellationToken)
        {
            if (productEditDto.Id == Guid.Empty || id != productEditDto.Id)
                return BadRequest("Gecersiz urun id'si.");

            if (await _dbContext.Products.AnyAsync(p => p.Name.ToLowerInvariant() == productEditDto.Name.ToLowerInvariant()
                && p.Id != productEditDto.Id, cancellationToken))
                return BadRequest("Bu isimde bir urun zaten mevcut.");

            var product = await _dbContext
                .Products
                .FirstOrDefaultAsync(x => x.Id == productEditDto.Id, cancellationToken);

            product.Name = productEditDto.Name;
            product.Price = productEditDto.Price;
            product.Description = productEditDto.Description;
            product.CategoryId = productEditDto.CategoryId;
            product.ModifiedOn = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok(product.Id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            // Empty Guid Example -> 00000000-0000-0000-0000-000000000000

            if (id == Guid.Empty)
                return BadRequest("Gecersiz urun id'si.");

            var product = await _dbContext
                .Products
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (product == null)
                return NotFound("Silmek istediginiz urun sistemde bulunamadi.");

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return NoContent();
        }


        [HttpPost("SeedInitialData")]
        public async Task<IActionResult> SeedInitialDataAsync(CancellationToken cancellationToken)
        {
            _dbContext.Products.AddRange(FakeDatabase.Products);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }


    }
}
