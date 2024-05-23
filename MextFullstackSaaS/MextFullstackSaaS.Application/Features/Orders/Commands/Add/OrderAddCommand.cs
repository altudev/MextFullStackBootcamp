using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommand : IRequest<ResponseDto<Guid>>
    {
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }

        public static Order MapToOrder(OrderAddCommand orderAddCommand)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                IconDescription = orderAddCommand.IconDescription,
                ColourCode = orderAddCommand.ColourCode,
                Model = orderAddCommand.Model,
                DesignType = orderAddCommand.DesignType,
                Size = orderAddCommand.Size,
                Shape = orderAddCommand.Shape,
                Quantity = orderAddCommand.Quantity,
                CreatedOn = DateTimeOffset.UtcNow,
            };
        }
    }
}
