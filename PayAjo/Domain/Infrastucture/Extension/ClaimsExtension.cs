using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Extension
{
  public static class ClaimsExtension
  {
    /// <summary>
    /// Get user id 
    /// </summary>
    /// <param name="principal"></param>
    /// <returns></returns>
    public static long GetUserId(this ClaimsPrincipal principal)
    {
      try
      {
        if (principal == null)
          throw new ArgumentNullException(nameof(principal));

        string userId = principal.FindFirst("UserId")?.Value;

        return long.Parse(userId);
      }
      catch
      {
        return 0;
      }


    }

    public static long GetMerchantId(this ClaimsPrincipal principal)
    {
      try
      {
        if (principal == null)
          throw new ArgumentNullException(nameof(principal));

        string userId = principal.FindFirst("MerchantId")?.Value;

        return long.Parse(userId);
      }
      catch
      {
        return 0;
      }


    }
  }
}
