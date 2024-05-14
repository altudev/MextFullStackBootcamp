using MextFullStack.Domain.Common;

namespace MextFullStack.Domain.Entities
{
    public class Product:EntityBase<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public override string CreatedByUserId { get; set; } = "system";
    }
}
