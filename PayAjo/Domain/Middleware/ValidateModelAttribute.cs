using Microsoft.AspNetCore.Mvc.Filters;
using PayAjo.Domain.Infrastucture.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Middleware
{
  public class ValidateModelAttribute : ActionFilterAttribute
  {

    /// <summary>
    /// OnActionExecuting
    /// </summary>
    /// <param name="context"></param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        var errors = context.ModelState.Keys
        .SelectMany(key => new Dictionary<string, string[]>()
        {
                    { key, context.ModelState[key].Errors.ToArray().Select(x=>x.ErrorMessage).ToArray() }
        });

        if (errors.Count() > 0)
        {
          throw new ModelValidationException("Validation Error(s)", errors);
        }
      }
    }

  }
}
