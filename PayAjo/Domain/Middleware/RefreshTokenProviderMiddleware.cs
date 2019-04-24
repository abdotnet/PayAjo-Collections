using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PayAjo.Data;
using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PayAjo.Domain.Middleware
{
    public class RefreshTokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _serializerSettings;

        public RefreshTokenProviderMiddleware(
                    RequestDelegate next)
        {
            _next = next;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals("/api/refresh", StringComparison.Ordinal))
            {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            return Task.CompletedTask;// GenerateToken(context);
        }

        private  void GenerateToken(HttpContext context)
        {
            //var refreshToken = context.Request.Form["refreshToken"].ToString();

            //if (string.IsNullOrWhiteSpace(refreshToken))
            //{
            //    context.Response.StatusCode = 400;
            //    await context.Response.WriteAsync("User must relogin.");
            //    return;
            //}

            ////var db = context.RequestServices.GetServices();
            ////var signInManager = context.RequestServices.GetService<SignInManager>();
            ////var userManager = context.RequestServices.GetService<UserManager>();

            //var refreshTokenModel = db.RefreshTokens
            //    .Include(x => x.User)
            //    .SingleOrDefault(i => i.Token == refreshToken);

            //if (refreshTokenModel == null)
            //{
            //    context.Response.StatusCode = 400;
            //    await context.Response.WriteAsync("User must relogin.");
            //    return;
            //}

            //if (!await signInManager.CanSignInAsync(refreshTokenModel.User))
            //{
            //    context.Response.StatusCode = 400;
            //    await context.Response.WriteAsync("User is unable to login.");
            //    return;
            //}

            //if (userManager.SupportsUserLockout && await userManager.IsLockedOutAsync(refreshTokenModel.User))
            //{
            //    context.Response.StatusCode = 400;
            //    await context.Response.WriteAsync("User is locked out.");
            //    return;
            //}

            ////var user = refreshTokenModel.User;
            ////var token = GetLoginToken.Execute(user, db, refreshTokenModel);
            ////context.Response.ContentType = "application/json";
            //await context.Response.WriteAsync(JsonConvert.SerializeObject(token, _serializerSettings));
        }

    }

    public class TokenProviderOptions
    {

    }

    public class GetLoginToken
    {
        public static TokenProviderOptions GetOptions()
        {
            //var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.Config.GetSection("TokenAuthentication:SecretKey").Value));

            return new TokenProviderOptions
            {
                //Path = Configuration.Config.GetSection("TokenAuthentication:TokenPath").Value,
                //Audience = Configuration.Config.GetSection("TokenAuthentication:Audience").Value,
                //Issuer = Configuration.Config.GetSection("TokenAuthentication:Issuer").Value,
                //Expiration = TimeSpan.FromMinutes(Convert.ToInt32(Configuration.Config.GetSection("TokenAuthentication:ExpirationMinutes").Value)),
                //SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };
        }

        //public static LoginResponseData Execute(UserModel user, PayAjoContext db, RefreshToken refreshToken = null)
        //{
        //    var options = GetOptions();
        //    var now = DateTime.UtcNow;

        //    var claims = new Claim[]
        //    {
        //        new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId, user.UserId),
        //        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
        //        new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
        //        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //    };

        //    var userClaims = db.UserClaims.Where(i => i.UserId == user.Id);
        //    foreach (var userClaim in userClaims)
        //    {
        //        claims.Add(new Claim(userClaim.ClaimType, userClaim.ClaimValue));
        //    }
        //    var userRoles = db.UserRoles.Where(i => i.UserId == user.Id);
        //    foreach (var userRole in userRoles)
        //    {
        //        var role = db.Roles.Single(i => i.Id == userRole.RoleId);
        //        claims.Add(new Claim(Extensions.RoleClaimType, role.Name));
        //    }

        //    if (refreshToken == null)
        //    {
        //        refreshToken = new RefreshToken()
        //        {
        //            UserId = user.Id,
        //            Token = Guid.NewGuid().ToString("N"),
        //        };
        //        db.InsertNew(refreshToken);
        //    }

        //    refreshToken.IssuedUtc = now;
        //    refreshToken.ExpiresUtc = now.Add(options.Expiration);
        //    db.SaveChanges();

        //    var jwt = new JwtSecurityToken(
        //        issuer: options.Issuer,
        //        audience: options.Audience,
        //        claims: claims.ToArray(),
        //        notBefore: now,
        //        expires: now.Add(options.Expiration),
        //        signingCredentials: options.SigningCredentials);
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    var response = new LoginResponseData
        //    {
        //        access_token = encodedJwt,
        //        refresh_token = refreshToken.Token,
        //        expires_in = (int)options.Expiration.TotalSeconds,
        //        userName = user.UserName,
        //        firstName = user.FirstName,
        //        lastName = user.LastName,
        //        isAdmin = claims.Any(i => i.Type == Extensions.RoleClaimType && i.Value == Extensions.AdminRole)
        //    };
        //    return response;
        //}
    }
}
