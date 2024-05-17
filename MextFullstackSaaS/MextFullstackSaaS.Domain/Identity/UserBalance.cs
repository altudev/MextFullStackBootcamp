using MextFullstackSaaS.Domain.Common;

namespace MextFullstackSaaS.Domain.Identity
{
    public class UserBalance:EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int Credits { get; set; }

        public ICollection<UserBalanceHistory> Histories { get; set; }
    }
}
