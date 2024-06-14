using MediatR;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.AddRange
{
    public class OrderAddRangeCommand:IRequest<ResponseDto<int>>
    {
        public int OrderCount { get; set; } = 50000;
    }
}
