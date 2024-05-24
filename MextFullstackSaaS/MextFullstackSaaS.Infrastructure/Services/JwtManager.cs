using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Settings;
using Microsoft.Extensions.Options;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class JwtManager:IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtManager(IOptions<JwtSettings> jwtSettingsOptions)
        {
            _jwtSettings = jwtSettingsOptions.Value;
        }
    }
}
