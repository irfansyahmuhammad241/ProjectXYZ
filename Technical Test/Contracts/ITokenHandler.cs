using System.Security.Claims;

namespace Technical_Test.Contracts
{
    public interface ITokenHandler
    {
        string GenerateToken(IEnumerable<Claim> claims);
        
    }
}
