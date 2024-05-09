using MextFullStack.Domain.Entities;

namespace MextFullStack.Domain.Dtos
{
    public class ProductGetAllDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        // Data Transfer Object (DTO)

        public static ProductGetAllDto FromProduct(Product product)
        {
            return new ProductGetAllDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }
    }
}
