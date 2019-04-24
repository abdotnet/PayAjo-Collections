using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class WithdrawalModel : Model
  {
    public long Id { get; set; }
    [Required]
    public long MerchantId { get; set; }
    //  public MerchantModel Merchant { get; set; }
    [Required]
    public long CustomerId { get; set; }
    // public CustomerModel Customer { get; set; }
    [Required]
    public decimal Amount { get; set; }
    public WithdrawalStatus WithdrawalStatus { get; set; }
    public string Message { get; set; }
    [Required]
    public string Password { get; set; }
  }


  public class WithdrawalLogModel : Model
  {
    [Required]
    public string  CustomerCode { get; set; }
    public decimal Amount { get; set; }
  }
  public class WithdrawalResponseModel : Model
  {
    public long Id { get; set; }
    [Required]
    public long MerchantId { get; set; }
    public MerchantModel Merchant { get; set; }
    [Required]
    public long CustomerId { get; set; }
    public CustomerModel Customer { get; set; }
    [Required]
    public decimal Amount { get; set; }
    public WithdrawalStatus WithdrawalStatus { get; set; }
    public string Message { get; set; }
    [Required]
    public string Password { get; set; }
  }
  public class WithdrawApprovalModel : Model
  {
    [Required]
      public long WithdrawalId { get; set; }
      public long AgentUserId { get; set; } = 10;

  }
}
