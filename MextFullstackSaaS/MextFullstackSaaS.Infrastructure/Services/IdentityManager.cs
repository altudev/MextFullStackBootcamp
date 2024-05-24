using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class IdentityManager:IIdentityService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public IdentityManager(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<JwtDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            var user = new User()
            {
                Id = id,
                Email = command.Email,
                UserName = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = id.ToString(),
                EmailConfirmed = true,
                Balance = new UserBalance()
                {
                    Id = Guid.NewGuid(),
                    Credits = 10,
                    UserId = id,
                    CreatedOn = DateTimeOffset.Now,
                    CreatedByUserId = id.ToString(),
                }
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User registration failed");
            }

            return await _jwtService.GenerateTokenAsync(user.Id,user.Email,cancellationToken);

        }

        public Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
