using Sistema_gestion_funeraria.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sistema_gestion_funeraria.Helper
{
    public class ClaimsHelper
    {
        public static List<Claim> GenerateClaims(AppUser user, IList<string> roles)
        {
            var claimsIdentity = new ClaimsIdentity();

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Nombre + " " + user.Apellido),
                new(ClaimTypes.GivenName, user.UserName),
                new(JwtRegisteredClaimNames.Email, user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
    }
}
