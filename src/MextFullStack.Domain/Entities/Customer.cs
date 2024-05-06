using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MextFullStack.Domain.Common;

namespace MextFullStack.Domain.Entities
{
    public class Customer:EntityBase<string>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedOn { get; set; }

        public Customer()
        {
            CreatedOn = DateTime.Now;

            Id = Guid.NewGuid().ToString();
        }
    }
}
