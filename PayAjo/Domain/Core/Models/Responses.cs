using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class Responses
  {
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    //public string[] ErrorMessage { get; set; }
    public object Result { get; set; }
  }
}
