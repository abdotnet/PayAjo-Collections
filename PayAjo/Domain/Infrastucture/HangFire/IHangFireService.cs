using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.HangFire
{
  public interface IHangFireService
  {
    /// <summary>
    /// Reset tech date job
    /// </summary>
    /// <returns></returns>
    Operation ResetTechDateJob();
    /// <summary>
    /// Debit tech customer balance ischargeable
    /// </summary>
    /// <returns></returns>
    Operation DebitTechCustomerBalanceOnIsChargeableJob();
    /// <summary>
    /// Weekly Sms Date Reset Job
    /// </summary>
    /// <returns></returns>
    Operation WeeklySmsDateResetJob();

    /// <summary>
    /// Sms weekly Sms job
    /// </summary>
    /// <returns></returns>
    Operation SendWeeklySmsJob();

    Operation PushSms();

    /// <summary>
    /// Send Sms HangFire Notification ..
    /// </summary>
    /// <returns></returns>
    Operation SendSmsHangFireNotification();
  }
}
