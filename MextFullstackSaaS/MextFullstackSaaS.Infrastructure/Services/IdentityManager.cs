using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Auth;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
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
        
        public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserAuthRegisterCommand.ToUser(command);

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User registration failed");
            }
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            
            return new UserAuthRegisterResponseDto(user.Id, user.Email, user.FirstName, token);

        }

        public async Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
          var user = await _userManager.FindByEmailAsync(command.Email);
          
          var jwtDto = await _jwtService.GenerateTokenAsync(user.Id,user.Email,cancellationToken);

          return jwtDto;
        }

        public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
                return true;
            
            return false;
        }

        public async Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return false;
            
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
