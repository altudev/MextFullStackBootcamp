using MextFullstackSaaS.Domain.Identity;

namespace MextFullstackSaaS.Application.Features.Users.Queries.GetProfile
{
    public class UserGetProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public decimal Credits { get; set; }
        public string PhoneNumber { get; set; }


      
        public static UserGetProfileDto Map(User user)
        {
            return new UserGetProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                ProfileImage = user.ProfileImage,
                Credits = user.Balance.Credits,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
