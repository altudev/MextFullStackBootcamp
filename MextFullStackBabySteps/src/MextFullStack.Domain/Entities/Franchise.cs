using MextFullStack.Domain.Common;

namespace MextFullStack.Domain.Entities
{
    public class Franchise:EntityBase<Guid>
    {
        public string Name { get; set; }

    }
}
