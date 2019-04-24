using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Middleware
{
  /// <summary>
  /// Middle ware to validate antiforgery token
  /// </summary>
  public class ValidateAntiForgeryTokenMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IAntiforgery _antiforgery;

    /// <summary>
    /// Validate anti forgery token
    /// </summary>
    /// <param name="next"></param>
    /// <param name="antiforgery"></param>
    public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
    {
      _next = next;
      _antiforgery = antiforgery;
    }

    /// <summary>
    ///  Invoke context function
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context)
    {
      if (HttpMethods.IsPost(context.Request.Method))
      {
        await _antiforgery.ValidateRequestAsync(context);
      }

      await _next(context);
    }

  }

  public static class ApplicationBuilderExtensions
  {
    public static IApplicationBuilder UseAntiforgeryTokens(this IApplicationBuilder app)
    {
      return app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();
    }
  }
}
