using MextFullStack.Domain.Common;
using MextFullStack.Domain.Enums;

namespace MextFullStack.Domain.Entities
{
    public class AccessControlLog:EntityBase<Guid>
    {
        public int UserId { get; set; }
        public string DeviceSerialNumber { get; set; }
        public AccessType AccessType { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
