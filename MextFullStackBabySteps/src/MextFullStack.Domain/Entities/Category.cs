using System.ComponentModel.DataAnnotations;
using MextFullStack.Domain.Common;

namespace MextFullStack.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public override DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
