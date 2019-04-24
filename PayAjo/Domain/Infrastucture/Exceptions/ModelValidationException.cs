using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Exceptions
{
  public class ModelValidationException : Exception
  {
    public readonly IEnumerable<KeyValuePair<string, string[]>> errors;

    public ModelValidationException(string message) : base(message)
    {
      errors = new List<KeyValuePair<string, string[]>>();
    }

    public ModelValidationException(string message, IEnumerable<KeyValuePair<string, string[]>> errors) : base(message)
    {
      this.errors = errors;
    }
  }
}
