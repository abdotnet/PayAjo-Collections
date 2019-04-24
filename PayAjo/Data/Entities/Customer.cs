using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class Customer : BaseEntity
  {
    public Customer()
    {
    }

    [Key]
    public long CustomerId { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Mobile { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    [MaxLength(100)]
    [EmailAddress]
    public string EmailAddress { get; set; }
    public bool IsLocked { get; set; }
    public bool IsCancelled { get; set; }
    public RegistrationChannel Channel { get; set; }
    public long MerchantId { get; set; }
    [ForeignKey("MerchantId")]
    public Merchant Merchant { get; set; }
    public string ApplicationCode { get; set; }
    public DateTime DateOfBirth { get; internal set; } = DateTime.Now;
    public string NokName { get; set; }
    public string NokEmail { get; set; }
    public string NokMobile { get; set; }
    public string NokRelationship { get; set; }
    public string NokAddress { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; } = "Nigeria";

    public bool IsSmsNotify { get; set; }
    //-=====

    public DateTime SmsStartDate { get; set; } = DateTime.Now;
    public DateTime SmsEndDate { get; set; } = DateTime.Now.AddDays(5);
    public string CustomerCode { get; set; }

    public bool IsActive { get; set; }

    [Required]
    public long UserId { get; set; }

    public string SignaturePath { get; set; }
    public string SignatureContentType { get; set; }
    public int SignatureContentLength { get; set; }

    public string PicturePath { get; set; }
    public string PictureContentType { get; set; }
    public int PictureContentLength { get; set; }
  }
}
