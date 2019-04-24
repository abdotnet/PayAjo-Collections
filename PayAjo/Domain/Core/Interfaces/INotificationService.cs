using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface INotificationService
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="phoneNos"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    Operation SendSms(string[] phoneNos, string message);
    Operation SendSmsKudiJob();
    Operation PushSms((long CustomerId, string TransactionNo, long CreatedBy) model, decimal amount, string transactionType);
    Operation SendSmsKudi(string[] v1, string v2);

    Task<string> SendEBulkSms(string senderName, string message, string[] recipients, int flash = 0);
    Task SaveSms(string message, string sender, long createdBy, string recipient, long customerId,
      long merchantId, string cost, string status, string totalSent);

    Operation SendSmsNotification1([Required]long merchantId);
    Task<int> SendSmsNotificationAsync([Required]long merchantId);
    Task<int> SendSmsNotificationToCustomerCodeAsync(string customerCode);
  }
}
