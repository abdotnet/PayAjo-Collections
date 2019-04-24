using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
    public class SettingModel : Model
    {

    public long Id { get; set; }
    [Required]
    public long? MerchantId { get; set; }
    public MerchantModel Merchant { get; set; }
    [Required]
    public decimal TechAmount { get; set; } = 50;// Technology Amount
    [Required]
    public decimal SmsAmount { get; set; } = 5;
    public decimal SmsUnit { get; set; }// rate of charge of this merhant .. 4.00 unit
    public bool IsActive { get; set; }
    [Required]
    public decimal MinimumBalance { get; set; } = 500;
  }
}
