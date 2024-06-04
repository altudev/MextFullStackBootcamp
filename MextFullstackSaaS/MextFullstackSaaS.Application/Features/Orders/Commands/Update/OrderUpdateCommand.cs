using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Update;

public class OrderUpdateCommand:IRequest<ResponseDto<Guid>>
{
    public Guid Id { get; set; }
    public string IconDescription { get; set; }
    public string ColourCode { get; set; }
    public AIModelType Model { get; set; }
    public DesignType DesignType { get; set; }
    public IconSize Size { get; set; }
    public IconShape Shape { get; set; }
    public int Quantity { get; set; }
    
    public static Order MapToOrder(OrderUpdateCommand orderUpdateCommand, Order oldOrder,Guid modifiedByUserId)
    {
        oldOrder.Size = orderUpdateCommand.Size;
        oldOrder.ColourCode = orderUpdateCommand.ColourCode;
        oldOrder.IconDescription = orderUpdateCommand.IconDescription;
        oldOrder.Model = orderUpdateCommand.Model;
        oldOrder.DesignType = orderUpdateCommand.DesignType;
        oldOrder.Shape = orderUpdateCommand.Shape;
        oldOrder.Quantity = orderUpdateCommand.Quantity;
        oldOrder.ModifiedOn = DateTimeOffset.UtcNow;
        oldOrder.ModifiedByUserId = modifiedByUserId.ToString();
        
        return oldOrder;
    }
}