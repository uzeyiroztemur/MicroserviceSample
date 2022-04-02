using Microservice.Core.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserPortalService.Entities.Models;

namespace UserPortalService.Business.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration Configuration { get; }  // appsetting dosyasından okumak için
        private TokenOptions TokenOptions { get; }
        private readonly DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();  // appsetting den okuduk nesneye cevirdik
            _accessTokenExpiration = DateTime.Now.AddMinutes(TokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<Role> operationClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenOptions.SecurityKey));
            var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = new JwtSecurityToken(
                issuer: TokenOptions.Issuer,
                audience: TokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredential
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new AccessToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<Role> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: TokenOptions.Issuer,
                audience: TokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<Role> operationClaims)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, $"{ user.FirstName} { user.LastName}"));
            operationClaims.Select(x => x.Name).ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            return claims;
        }
    }
}