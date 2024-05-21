using MediatR;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommand:IRequest<Guid>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
