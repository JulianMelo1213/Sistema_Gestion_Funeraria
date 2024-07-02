using System.Security.Claims;

namespace Sistema_gestion_funeraria.Interface
{
    public interface ITokenService
    {
        string GenerateJWTToken(IList<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
