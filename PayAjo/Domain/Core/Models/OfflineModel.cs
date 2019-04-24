using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class OfflineModel : Model
  {
    [Required]
    public string CustomerCode { get; set; }
    [Required]
    public string AgentUserName { get; set; }
    [Required]
    public decimal Amount { get; set; }

    [Required]
    public string TransactionType { get; set; }

    [Required]
    public long MerchantId { get; set; }
  }
}
