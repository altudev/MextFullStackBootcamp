using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Identity;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IJwtService
    {
        JwtDto GenerateToken(User user,List<string> roles);
        Task<JwtDto> GenerateTokenAsync(Guid userId, string email,CancellationToken cancellationToken);
    }
}
