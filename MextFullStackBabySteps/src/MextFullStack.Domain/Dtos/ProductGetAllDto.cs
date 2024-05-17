using MextFullStack.Domain.Common;
using MextFullStack.Domain.Entities;

namespace MextFullStack.Domain.Dtos
{
    public sealed class ProductGetAllDto:EntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Data Transfer Object (DTO)

        public static ProductGetAllDto FromProduct(Product product)
        {
            return new ProductGetAllDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Description = product.Description,
            };
        }
    }
}
