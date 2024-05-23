using MextFullstackSaaS.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MextFullstackSaaS.Infrastructure.Persistence.Seeders
{
    public class UserSeeder: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User
            {
                Id = new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                UserName = "mextuser",
                NormalizedUserName = "MEXTUSER",
                Email = "mextuser@gmail.com",
                NormalizedEmail = "MEXTUSER@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Mext",
                LastName = "User",
                CreatedOn = Convert.ToDateTime("2024-05-22T10:16:31+00:00"),
                CreatedByUserId = "35c16d2a-f25b-4701-9a74-ea1fb7ed6d93",
                SecurityStamp = "6c185769-9f7b-47e8-a70c-dc7b892089de",
            };

            user.PasswordHash = CreatePasswordHash(user, "123mextuser123");

            builder.HasData(user);
        }


        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();

            return passwordHasher.HashPassword(user, password);
        }
    }
}
