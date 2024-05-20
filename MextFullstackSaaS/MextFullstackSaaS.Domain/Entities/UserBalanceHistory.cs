using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Enums;

namespace MextFullstackSaaS.Domain.Entities
{
    public class UserBalanceHistory : EntityBase<Guid>
    {
        public Guid UserBalanceId { get; set; }
        public UserBalance UserBalance { get; set; }

        public UserBalanceHistoryType Type { get; set; }
        public int Amount { get; set; }
        public int PreviousCredits { get; set; }
        public int CurrentCredits { get; set; }
    }
}
