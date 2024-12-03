using Aff.Int.API.Core.Constants;
using Aff.Int.API.Core.Extensions;
using Aff.Int.API.Core.Models;
using Aff.Int.API.Core.Models.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Aff.Int.API.Core.Services
{
    public class TokenAuthenticationService(IUserManagementService service,
        IOptions<TokenManagementOptions> tokenManagementAccessor) : IAuthenticateService
    {
        public Tuple<bool, Token> IsAuthenticated(TokenRequest request)
        {
            var token = new Token();
            var tokenManagement = tokenManagementAccessor.Value;

            if (tokenManagement is null)
            {
                return Tuple.Create(false, token);
            }

            var siteName = request.Username;
            var realUserName = request.Username;

            if (request.Username.Contains('@'))
            {
                var temp = request.Username.Split('@');
                siteName = temp[0];
                realUserName = temp[1];
            }

            if (!service.IsValidUser(realUserName, request.Password))
            {
                return Tuple.Create(false, token);
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, realUserName),
                new (CustomClaimType.Site, siteName),
                new (CustomClaimType.IsShowIPVN, request.IsShowIpvn.ToString(), ClaimValueTypes.Boolean)
             };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var encryptCredentials = new EncryptingCredentials(key, JwtConstants.DirectKeyUseAlg,
                SecurityAlgorithms.Aes256CbcHmacSha512);
            var handler = new JsonWebTokenHandler();
            var utcDateTimeNow = DateTimeOffset.Now.UtcDateTime;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = tokenManagement.Issuer,
                Audience = tokenManagement.Audience,
                Subject = new ClaimsIdentity(claims),
                IssuedAt = utcDateTimeNow,
                NotBefore = utcDateTimeNow,
                Expires = utcDateTimeNow.AddMinutes(tokenManagement.AccessExpiration),
                SigningCredentials = credentials,
                EncryptingCredentials = encryptCredentials
            };

            token.AccessToken = handler.CreateToken(tokenDescriptor);
            token.TokenType = handler.TokenType.Name;
            token.ExpiresIn = tokenManagement.AccessExpiration;

            return Tuple.Create(true, token);
        }
    }
}
