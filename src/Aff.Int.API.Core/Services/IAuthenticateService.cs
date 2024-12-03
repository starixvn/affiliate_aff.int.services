using Aff.Int.API.Core.Models;

namespace Aff.Int.API.Core.Services
{
    public interface IAuthenticateService
    {
        Tuple<bool, Token> IsAuthenticated(TokenRequest request);
    }
}
