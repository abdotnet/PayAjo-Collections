using IdentityModel;
using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Extension
{
    public static class SecurityExtensions
    {
        public static List<Claim> GetClaims(this UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Email, user.EmailAddress),
                new Claim(JwtClaimTypes.BirthDate, user.DateOfBirth.ToString("d MMM yyyy")),
                new Claim(JwtClaimTypes.FamilyName, user.LastName),
                new Claim(JwtClaimTypes.GivenName, user.FirstName),
                //new Claim(JwtClaimTypes.Gender, user.Gender)
            };
            if (!string.IsNullOrEmpty(user.Mobile))
            {
                claims.Add(new Claim(JwtClaimTypes.PhoneNumber, user.Mobile));
            }
            return claims;
        }


        public static string GetUserId(this IIdentity identity)
        {
            var id = identity as ClaimsIdentity;
            var query = from claims in id.Claims
                        where claims.Type == JwtClaimTypes.Subject
                        select claims.Value;
            return query.FirstOrDefault();
        }
    }
}
