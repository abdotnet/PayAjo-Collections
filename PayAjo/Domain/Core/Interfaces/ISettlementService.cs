using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface ISettlementService
  {
    Task<SmsNotificationModel> GetSmsNotification(long merchantId);
  }
}
