using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Auth;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken);
    }
}
