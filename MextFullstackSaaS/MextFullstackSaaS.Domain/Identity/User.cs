using MextFullstackSaaS.Domain.Common;
using MextFullstackSaaS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MextFullstackSaaS.Domain.Identity
{
    // AppUser / ApplicationUser // UserManager<User> _userManager.SignInAsync()
    public class User:IdentityUser<Guid>, IEntity<Guid>,ICreatedByEntity,IModifiedByEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public UserBalance Balance { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
