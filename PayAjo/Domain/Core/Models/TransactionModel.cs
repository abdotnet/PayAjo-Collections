using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class TransactionModel : Model
  {
    public long Id { get; set; }
    public string TransactionNo { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string TransactionType { get; set; } // DR or CR
                                                //[Required]
    public string TransactionCode { get; set; }
    [Required]
    public string TransactionChannel { get; set; }
    [Required]
    public long MerchantId { get; set; }
    //public MerchantModel Merchant { get; set; }
    [Required]
    public long CustomerId { get; set; }
    // public CustomerModel Customer { get; set; }
    public bool IsNotified { get; set; }
    public bool IsService { get; set; }
    public long? CollectionTypeId { get; set; }
    //public CollectionTypeModel CollectionType { get; set; }
    public string TransactionMessage { get; set; }

    public DateTime TechFeeStartDate { get; set; } = DateTime.Now;
    public DateTime TechFeeEndDate { get; set; } = DateTime.Now;
    public string TransactionMapCode { get; set; }

    // public AgentModel Agent { get; set; }
    public string UserName { get; set; }
    public string CustomerCode { get; set; }
    public TransactionModel()
    {
      TransactionNo = GenerateTransactionNo().Result;
    }
  }

  public class TransactionLogger:Model
  {
    public string CustomerCode { get; set; }
    public decimal Amount { get; set; }
  }
  public class TransactionLogModel : Model
  {
    public long Id { get; set; }
    public string TransactionNo { get; set; }
    [Required]
    public decimal Amount { get; set; }
    public string TransactionType { get; set; } // DR or CR
                                                //[Required]
    public string TransactionCode { get; set; }
    public long MerchantId { get; set; }
    //public MerchantModel Merchant { get; set; }
    public long CustomerId { get; set; }
    // public CustomerModel Customer { get; set; }
    public bool IsNotified { get; set; }
    public bool IsService { get; set; }
    public long? CollectionTypeId { get; set; }
    //public CollectionTypeModel CollectionType { get; set; }
    public string TransactionMessage { get; set; }

    public DateTime TechFeeStartDate { get; set; } = DateTime.Now;
    public DateTime TechFeeEndDate { get; set; } = DateTime.Now;
    public string TransactionMapCode { get; set; }
    public string TransactionChannel { get; set; }
    // public AgentModel Agent { get; set; }
    public string UserName { get; set; }
    [Required]
    public string CustomerCode { get; set; }
    public TransactionLogModel()
    {
      TransactionNo = GenerateTransactionNo().Result;
    }
  }

  public class TransactionJobModel : Model
  {
    public long Id { get; set; }
    public string TransactionNo { get; set; }

    public decimal Amount { get; set; }

    public string TransactionType { get; set; } // DR or CR
                                                //[Required]
    public string TransactionCode { get; set; }
    public string TransactionChannel { get; set; }

    public long CustemerMerchantId { get; set; }
    public long SystemMerchantId { get; set; }

    public long CustomerId { get; set; }
    public CustomerModel Customer { get; set; }
    public bool IsNotified { get; set; }
    public bool IsService { get; set; }
    public string TransactionMessage { get; set; } = "Back ground job";
    public DateTime TechFeeStartDate { get; set; } = DateTime.Now;
    public DateTime TechFeeEndDate { get; set; } = DateTime.Now;
    public string TransactionMapCode { get; set; }

    public AgentModel Agent { get; set; }
    public TransactionJobModel()
    {
      TransactionNo = GenerateTransactionNo().Result;
    }
  }

  public class TransactionReponseModel : Model
  {
    public long Id { get; set; }
    public string TransactionNo { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string TransactionType { get; set; } // DR or CR
                                                //[Required]
    public string TransactionCode { get; set; }
    [Required]
    public long MerchantId { get; set; }
    public MerchantModel Merchant { get; set; }
    [Required]
    public long CustomerId { get; set; }
    public CustomerModel Customer { get; set; }
    public bool IsNotified { get; set; }
    public bool IsService { get; set; }
    public long? CollectionTypeId { get; set; }
    public CollectionTypeModel CollectionType { get; set; }
    public string TransactionMessage { get; set; }
    public string TransactionChannel { get; set; }
    public DateTime TechFeeStartDate { get; set; } = DateTime.Now;
    public DateTime TechFeeEndDate { get; set; } = DateTime.Now;
    public string TransactionMapCode { get; set; }

    public AgentModel Agent { get; set; }
    public string UserName { get; set; }
    public string MerchantName { get; set; }
    public string AgentName { get; set; }
    public TransactionReponseModel()
    {
      TransactionNo = GenerateTransactionNo().Result;
    }
  }
  public class MerchanTransactionModel : Model
  {
    public long Id { get; set; }
    public string TransactionNo { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string TransactionType { get; set; } // DR or CR
                                                //[Required]
    public string TransactionCode { get; set; }
    [Required]
    public long MerchantId { get; set; }
    //public MerchantModel Merchant { get; set; }
    [Required]
    public long CustomerId { get; set; }
    // public CustomerModel Customer { get; set; }
    public bool IsNotified { get; set; }
    public bool IsService { get; set; }
    public string TransactionChannel { get; set; }
    public long? CollectionTypeId { get; set; }
    //public CollectionTypeModel CollectionType { get; set; }
    public string TransactionMessage { get; set; }

    public DateTime TechFeeStartDate { get; set; } = DateTime.Now;
    public DateTime TechFeeEndDate { get; set; } = DateTime.Now;
    public string TransactionMapCode { get; set; }
    public CustomerModel Customer { get; set; }
    public MerchantModel Merchant { get; set; }

  }

  public static class TChannel // transaction channel
  {
    public static  string SMS { get; set; } = "SMS";
    public static string TechFee { get; set; } = "TECHFEE";
    public static string Withdrawal { get; set; } = "WITHDRAWAL";
    public static string Payment { get; set; } = "PAYMENT";
  }
}
