using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class AgentModel : Model
  {
    public long AgentId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
    [Required]
    public long MerchantId { get; set; }
    // public MerchantModel Merchant { get; set; }
    [Required]
    public string UserName { get; set; }

  }

  public class AgentDashboard
  {
    public decimal AgentTotalCreditMonth { get; set; }
    public decimal AgentTotalCreditWeek { get; set; }
    public decimal AgentTotalDebitWeek { get; set; }
    // public decimal AgentTotalBalance { get; set; }
  }
  public class MerchantDashboard
  {
    public decimal TotalCreditMonth { get; set; }
    public decimal TotalCreditWeek { get; set; }
    public decimal TotalDebitWeek { get; set; }
    public decimal TotalBalance { get; set; }
  }
}
