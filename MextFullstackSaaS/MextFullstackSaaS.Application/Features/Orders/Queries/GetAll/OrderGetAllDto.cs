using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
