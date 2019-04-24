using PayAjo.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class Withdrawal : BaseEntity
  {
    public long Id { get; set; }
    [Required]
    public long MerchantId { get; set; }

    public long CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public decimal Amount { get; set; }
    public WithdrawalStatus WithdrawalStatus { get; set; }
    public bool IsCancelled { get; set; }
    public string Message { get; set; }
  }

  
}
