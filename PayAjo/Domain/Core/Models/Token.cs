using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
    public class Token
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public UserModel user { get; set; }
    }

    public class Parameters
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }

    public class ResponseData
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }

    public class TokenConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double AccessExpireMinutes { get; set; }
        public int RefreshExpireMinutes { get; set; }
    }

    public class TokenResource
    {
        public string Token { get; set; }
        public long Expiry { get; set; }
    }

    public class AuthorizationTokensResource
    {
        public TokenResource AccessToken { get; set; }
        public TokenResource RefreshToken { get; set; }
    }

    public class RefreshTokenResource
    {
        public string RefreshToken { get; set; }
    }
}
