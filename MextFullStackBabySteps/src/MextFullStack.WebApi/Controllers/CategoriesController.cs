using MextFullStack.Domain.Dtos;
using MextFullStack.Domain.Entities;
using MextFullStack.Persistence.Contexts;
using MextFullStack.WebApi.Data;
using MextFullStack.WebApi.RequestModels;
using MextFullStack.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RequestCounterManager _requestCounterManager;

        public CategoriesController(ApplicationDbContext dbContext, RequestCounterManager requestCounterManager)
        {
            _dbContext = dbContext;
            _requestCounterManager = requestCounterManager;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            _requestCounterManager.Increment();

            return Ok(FakeDatabase.Categories);
        }

        [HttpGet("[action]")]
        public IActionResult GetAllForSelect()
        {
            _requestCounterManager.Increment();

            var categories = FakeDatabase
                .Categories
                .Where(x => x.IsActive)
                .Select(c => CategoryGetAllForSelectDto.FromCategory(c))
                .ToList();

            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            _requestCounterManager.Increment();

            var category = FakeDatabase
                .Categories
                .FirstOrDefault(p => p.Id == id);

            if (category == null)
                return NotFound("Aradaginiz urun sistemde bulunamadi.");

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryRequestModel createCategoryRequestModel)
        {
            _requestCounterManager.Increment();

            var category = new Category
            {
                Name = createCategoryRequestModel.Name,
                Description = createCategoryRequestModel.Description,
                IsActive = true,
                Id = Guid.NewGuid(),
            };

            if (category.Name.Length <= 2)
                return BadRequest("Kategori ismi en az 2 karakter olmalidir.");

            if (category.Description.Length <= 10)
                return BadRequest("Kategori aciklamasi 10 karakterden buyuk olmalidir.");


            if (FakeDatabase.Categories.Any(c => c.Name.ToLowerInvariant() == category.Name.ToLowerInvariant()))
                return BadRequest("Bu isimde bir kategori zaten mevcut.");

            FakeDatabase.Categories.Add(category);

            return Ok(category.Id);
        }

    }
}
