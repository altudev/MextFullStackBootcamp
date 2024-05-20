using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Identity;

namespace MextFullstackSaaS.Domain.Entities
{
    public class UserBalance : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public int Credits { get; set; }

        public ICollection<UserBalanceHistory> Histories { get; set; }
    }
}
