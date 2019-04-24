using PayAjo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class NotificationModel : Model
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
    public string  CustomerName { get; set; }
  }
}
