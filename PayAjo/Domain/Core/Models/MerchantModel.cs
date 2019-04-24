using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class MerchantModel : Model
  {
    public long Id { get; set; }
    // Business name
    public string Name { get; set; }
    public string MerchantCode { get; set; }
    public string Address { get; set; }
    public string BVN { get; set; }
    public string MerchantNo { get; set; }
    public string GovtRegNo { get; set; }
    public string BusinessMobile { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; } = "Nigeria";

    public DateTime SmsDate { get; set; }
    public DateTime TechDate { get; set; }
  }

  public class MerchantLoginModel : Model
  {
    [Required]
    public string FirstName { get; set; }
    public string MerchantCode { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Mobile { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string BusinessName { get; set; }
    [Required]
    public string Address { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string EmailAddress { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string BVN { get; set; }
    public string Country { get; set; }
    public string GovtRegNo { get; set; }
    [Required]
    public string UserName { get; set; }

    public DateTime SmsDate { get; set; }
    public DateTime TechDate { get; set; }

  }
}
