using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class Notification : BaseEntity
  {
    public long Id { get; set; }
    public string Sender { get; set; } // Subject  ..
    public NotificationType NotificationType { get; set; }
    public string Message { get; set; } // body of the message
    public string Recipient { get; set; } // phone no or email
    public NotificationSystem NotificationSystem { get; set; }
    public decimal Cost { get; set; }
    public long SendToUserId { get; set; }
    public bool IsNotify { get; set; }
    public long MerchantId { get; set; }
    public long CustomerId { get; set; }
    public int TotalMessageSent { get; set; }
    public bool IsPaid { get; set; }
  }

  /// <summary>
  /// Charge Type
  /// </summary>
  public enum ChargeType
  {
     SmsFee,
     TechFee
  }
  /// <summary>
  /// Notification Type
  /// </summary>
  public enum NotificationType
  {
    Sms = 1,
    Email = 2
  }

  /// <summary>
  /// Notification System
  /// </summary>
  public enum NotificationSystem
  {
    UserAccount = 0,
    Transacition = 1,
    CollectionType = 2,
    Notification = 3,
    Withdrawal = 4,

  }
}
