using MextFullStack.Domain.Common;

namespace MextFullStack.Domain.Entities
{
    public class Customer:EntityBase<string>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public override DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Customer()
        {
            CreatedOn = DateTime.Now;

            Id = Guid.NewGuid().ToString();
        }
    }
}
