using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        //When ı added the Microsof.Extensions.Configuration.Binder in ManageNuget.

        //IConfiguration can help read the appstettings.json
        public IConfiguration Configuration { get; }
        //when ı read from appsettings.json ı will send the object
        private TokenOptions _tokenOptions;
        //which time access token will be expiration...
        private DateTime _accessTokenExpiration;
        //we did the injection
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //it is matching the from API appsettings.json to TokenOptions fields you can check them...

            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
           




        }
        //it is creating the token for user... and give the claims then it will create the token depending on user and claims.
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //it is taken expirationtime from appsetting.json to TokenOptions they will match each other as a same field.
            //it is added 10 min expiration time check the appsettings.json in WebAPI
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //it is creating the securityKey from tokenoptions
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //which algorith will use in securityKey.then before SigningCredentialsHelper class created for
            //which algorithm will use when you check there.SHA-512
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //we wrote the method it includes TokenOptions,user,signingCredentials,operationClaims(Authority)
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            //jwt is created JwtSecurityToken
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            //also all options is creating instance in jwt and return it.
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }

}
