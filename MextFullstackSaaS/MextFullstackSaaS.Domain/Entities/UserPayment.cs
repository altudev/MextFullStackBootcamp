using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Enums;
using MextFullstackSaaS.Domain.Identity;
using MextFullstackSaaS.Domain.ValueObjects;

namespace MextFullstackSaaS.Domain.Entities
{
    public class UserPayment:EntityBase<Guid>
    {
        public string ConversationId { get; set; }
        public string BasketId { get; set; }
        public string Token { get; set; }
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public PaymentStatus Status { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string? Note { get; set; }
        public decimal? RefundedAmount { get; set; }

        public UserPaymentDetail UserPaymentDetail { get; set; }

        public ICollection<UserPaymentHistory> Histories { get; set; }
    }
}
