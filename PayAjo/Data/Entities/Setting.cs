using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class Setting : BaseEntity
  {
    public long Id { get; set; }
    public long? MerchantId { get; set; }
    [ForeignKey("MerchantId")]
    public Merchant Merchant { get; set; }
    public decimal TechAmount { get; set; } = 50;// Technology Amount
    public decimal SmsAmount { get; set; } = 5;
    public decimal SmsUnit { get; set; }// rate of charge of this merhant .. 4.00 unit
    public decimal MinimumBalance { get; set; }
    public bool IsActive { get; set; }
    public bool IsCancelled { get; set; }
  }
}
