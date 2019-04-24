using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class Merchant : BaseEntity
  {
    public long MerchantId { get; set; }
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
    public string ImagePath { get; set; }
    public string ImageContentType { get; set; }
    public int ImageContentLength { get; set; }
    public bool IsCancelled { get; set; }
    public string EmailAddress { get; set; }
    public DateTime SmsDate { get; set; }
    public DateTime TechDate { get; set; }
    public decimal MinimumBalance { get; set; }
    public decimal SmsCost { get; set; }
    public decimal TechFeeCost { get; set; }
  }
}
