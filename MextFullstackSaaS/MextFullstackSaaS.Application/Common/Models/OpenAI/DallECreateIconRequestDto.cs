using MextFullstackSaaS.Application.Features.Orders.Commands.Add;
using MextFullstackSaaS.Domain.Enums;

namespace MextFullstackSaaS.Application.Common.Models.OpenAI;

public class DallECreateIconRequestDto
{
    public string Description { get; set; }
    public string ColourCode { get; set; }
    public AIModelType Model { get; set; }
    public DesignType DesignType { get; set; }
    public IconSize Size { get; set; }
    public IconShape Shape { get; set; }
    public int Quantity { get; set; }
    
    public static DallECreateIconRequestDto MapFromOrderAddCommand(OrderAddCommand orderAddCommand)
    {
        return new DallECreateIconRequestDto
        {
            Description = orderAddCommand.IconDescription,
            ColourCode = orderAddCommand.ColourCode,
            Model = orderAddCommand.Model,
            DesignType = orderAddCommand.DesignType,
            Size = orderAddCommand.Size,
            Shape = orderAddCommand.Shape,
            Quantity = orderAddCommand.Quantity
        };
    }
}