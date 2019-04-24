using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
    public class ResponseModel
    {
    public string ResponseCode { get; set; }
    public string ResponseDesc { get; set; }
    public string[] Errors { get; set; }
    public object ResponseData { get; set; }
    public IEnumerable<KeyValuePair<string, string[]>> ValidationErrors { get; set; }
  }
}
