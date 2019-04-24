using PayAjo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class SettlementModel
  {
  }

  public class SmsNotificationModel
  {
    public long NotifyCount { get; set; }
    public decimal SmsCost { get; set; }

    public List<NotificationModel> Notifications { get; set; } = new List<NotificationModel>();

  }


}
