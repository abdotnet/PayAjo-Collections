using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture.Extension;
using PayAjo.Domain.Middleware;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Api base controller
  /// </summary>
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [ValidateModel]
  public class ApiController : Controller
  {
  
    /// <summary>
    /// get user id
    /// </summary>
    public long UserId
    {
      get
      {
        // var epoch = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        return User.GetUserId();

      }
    }
    /// <summary>
    /// Merchant Id
    /// </summary>
    public long MerchantId
    {
      get
      {
        return User.GetMerchantId();

      }
    }

    // public Operation<string> GenerateUniqueEmployerCode() => Operation.Create(() =>
    //{
    //  uint RandomInt(RandomNumberGenerator rng)
    //  {
    //    var intByte = new byte[4];
    //    rng.GetBytes(intByte);
    //    return BitConverter.ToUInt32(intByte, 0);
    //  }
    //  using (var rng = new RNGCryptoServiceProvider())
    //  {
    //    var i1 = Math.Abs(RandomInt(rng));
    //    var i2 = Math.Abs(RandomInt(rng));
    //    return $"U-{DateTime.Now.ToString("yyddMM")}-{i1.ToString("X")}";
    //  }
    //});

  }
}
