using MextFullStack.Domain.Common;

namespace MextFullStack.Domain.Entities
{
    public class Product:EntityBase<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
