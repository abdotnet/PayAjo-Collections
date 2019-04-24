using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture
{
  public enum CreditPlan
  {
    Day = 1,
    Week = 2,
    Month = 3
  }
  public static class TransactionType
  {
    public static string Debit { get; set; } = "DR";
    public static string Credit { get; set; } = "CR";
    public static string None { get; set; } = "None";
  }

  public enum TransType
  {
    None,
    Debit,
    Credit
  }
  public enum WithdrawalType
  {
    Pending,
    Approved,
    Paid,
    All
  }
  public static class Constants
  {

    public static class Roles
    {
      public static long CentralAdmin { get; set; } = 1;
      public static long MerchantAdmin { get; set; } = 2;
      public static long MerchantAgent { get; set; } = 3;
      public static long Customer { get; set; } = 4;
    }
    public static class Tokens
    {
      public const string OnBoardUser = "OnBoardUser";
    }

    public static class AuthScheme
    {
      public const string Cookie = "cookie";
      public const string OIDC = "oidc";
      public const string JWT = "jwt";
    }

    public static class TempData
    {
      public const string Message = "message";
    }

    public static class Session
    {
      public const string ReturnUrl = "returnUrl";
    }

    public static class Cors
    {
      public const string EnableAll = "EnableAll";
      public const string WithCredentials = "WithCredentials";
      public const string EnableAllWithCredentials = "EnableAllWithCredentials";
    }

    public class NotificationPayload
    {

      public string TransactionNo { get; set; }
      public string CustomerCode { get; set; }
      public string  TransactionType { get; set; }
      public DateTime EntryDate { get; set; } = DateTime.Now;
      public string  PhoneNo { get; set; }
      public decimal Amount { get; set; }
      public long CustomerId { get; set; }
      public long TransactionId { get; set; }
      //public long MerchantId { get; set; }

    }
  }
}
