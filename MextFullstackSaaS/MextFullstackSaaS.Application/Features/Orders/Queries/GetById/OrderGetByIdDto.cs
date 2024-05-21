using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.Identity;

namespace MextFullstackSaaS.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
        public DateTimeOffset CreatedOn { get; set; }
    }
}
