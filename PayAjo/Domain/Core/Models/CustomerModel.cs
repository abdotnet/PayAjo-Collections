using PayAjo.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class CustomerModel : Model
  {

    public CustomerModel()
    {
    }

    public string UserName { get; set; }
    public long CustomerId { get; set; }
    public string Title { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [Required]
    public string Mobile { get; set; }
    public string Gender { get; set; }
    [Required]
    public string Address { get; set; }
    public string EmailAddress { get; set; }
    public bool IsLocked { get; set; }
    public RegistrationChannel Channel { get; set; }
    [Required]
    public long MerchantId { get; set; }
    public Merchant Merchant { get; set; }

    public DateTime DateOfBirth { get; internal set; } = DateTime.Now;
    public string NokName { get; set; }
    public string NokEmail { get; set; }
    public string NokMobile { get; set; }
    public string NokRelationship { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; } = "Nigeria";
    public string CustomerCode { get; set; }

    public decimal TotalCustomerBalance { get; set; }
    public decimal UserId { get; set; }
    public decimal CustomerBalance { get; set; }

    public string SignaturePath { get; set; }
    public string SignatureContentType { get; set; }
    public int SignatureContentLength { get; set; }

    public string PicturePath { get; set; }
    public string PictureContentType { get; set; }
    public int PictureContentLength { get; set; }
  }

  public enum StatusCode
  {
    Both, Active, InActive
  }
  public class CustomerLoginModel : Model
  {
    public long CustomerId { get; set; }
    public string Title { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [Required]
    public string Mobile { get; set; }
    public string Gender { get; set; }

    public string CustomerCode { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Address { get; set; }
    public string EmailAddress { get; set; }
    public bool IsLocked { get; set; }
    public RegistrationChannel Channel { get; set; }
    [Required]
    public long MerchantId { get; set; }
    //public Merchant Merchant { get; set; }

    public DateTime DateOfBirth { get; internal set; } = DateTime.Now;
    public string NokName { get; set; }
    public string NokEmail { get; set; }
    public string NokMobile { get; set; }
    public string NokRelationship { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; } = "Nigeria";
    [Required]
    public RegType RegType { get; set; } = RegType.Customer;

    public bool IsSmsNotify { get; set; }
    //-=====
    public DateTime TransStartDate { get; set; } = DateTime.Now;
    public DateTime TransEndDate { get; set; } = DateTime.Now;

    public DateTime SmsStartDate { get; set; } = DateTime.Now;
    public DateTime SmsEndDate { get; set; } = DateTime.Now;

    public string UserName { get; set; }
    public CustomerLoginModel()
    {
      // CustomerCode = GetCustomerCode().Result;
    }

    public long UserId { get; set; }
    public bool IsActive { get; set; }

  }

  public class CustomerWebLoginModel : Model
  {
    public long CustomerId { get; set; }
    public string Title { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [Required]
    public string Mobile { get; set; }
    public string Gender { get; set; }

    public string CustomerCode { get; set; }
    public string Password { get; set; }
    [Required]
    public string Address { get; set; }
    public string EmailAddress { get; set; }
    public bool IsLocked { get; set; }
    public RegistrationChannel Channel { get; set; }
    public long MerchantId { get; set; }
    //public Merchant Merchant { get; set; }

    public DateTime DateOfBirth { get; internal set; } = DateTime.Now;
    public string NokName { get; set; }
    public string NokEmail { get; set; }
    public string NokMobile { get; set; }
    public string NokRelationship { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; } = "Nigeria";
    public RegType RegType { get; set; } = RegType.Customer;

    public bool IsSmsNotify { get; set; }
    //-=====
    public DateTime TransStartDate { get; set; } = DateTime.Now;
    public DateTime TransEndDate { get; set; } = DateTime.Now;

    public DateTime SmsStartDate { get; set; } = DateTime.Now;
    public DateTime SmsEndDate { get; set; } = DateTime.Now;

    public string UserName { get; set; }
    public long UserId { get; set; }
    public bool IsActive { get; set; }

  }
  public enum RegType
  {
    Customer = 0,
    Agent = 1
  }

  public enum UploadType
  {
    Picture,
    Signature
  }

  public class ImageUpload
  {
    public long CustomerId { get; set; }
    public string ImagePath { get; set; }
    public int ContentLength { get; set; }
    public string ContentType { get; set; }
  }
  public class CustomerInfo
  {
    public string MASTERNUMBER { get; set; }
    public string LASTNAME { get; set; }
    public string FIRSTNAME { get; set; }
    public string MIDDLENAME { get; set; }
    public string ADDRESS { get; set; }
    public string PHONENUMBER { get; set; }
    public string BALANCE { get; set; }
    public string TRANSACTIONDATE { get; set; }
    public string UserName { get; set; }
  }

  public class CustomerMerchant
  {
    public CustomerModel[] CustomerModel { get; set; }
    public decimal TotalCustomers { get; set; }
  }


  public class CustomerUpdateModel
  {
    [Required]
    public long CustomerId { get; set; }
    public string NokName { get; set; }
    public string NokPhone { get; set; }
    public string NoKEmail { get; set; }
    public string NokAddress { get; set; }

    public string NokRelationship { get; set; }

    public long CreatedBy { get; set; }
    public long MerchantId { get; set; }
  }

  public class TransactionDay
  {
    public static string Monday { get; set; } = "MON";
    public static string Tuesday { get; set; } = "TUE";
    public static string Wednesday { get; set; } = "WED";
    public static string Thurday { get; set; } = "THU";
    public static string Friday { get; set; } = "FRI";
    public static string Saturday { get; set; } = "SAT";
    public static string Sunday { get; set; } = "SUN";
  }
}
