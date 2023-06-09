using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        //this ICollection<Claim> claims = when we see this code
        //there is no in here normal.it is coming from .Net directly we are just extension them.
        //normally we have everyeach one have to new them
        //but no need we can shortly use them with extension method as a claim
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
