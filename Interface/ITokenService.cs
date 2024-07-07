using Sistema_gestion_funeraria.Models;
using System.Security.Claims;

namespace Sistema_gestion_funeraria.Interface
{
    public interface ITokenService
    {
        string GenerateJWTToken(IList<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<string> StoreRefreshTokenAsync(AppUser user);
        Task<bool> RemoveRefreshTokenAsync(AppUser user);
    }
}
