using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MextFullstackSaaS.Application.Common.Helpers
{
    public static class JwtHelper
    {
        public static IEnumerable<Claim> ReadClaimsFromToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadJwtToken(accessToken);

            return jwtToken.Claims;
        }
    }
}
