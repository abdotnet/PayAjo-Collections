using PayAjo.Data;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
  public class SettlementService : Service, ISettlementService
  {
    private readonly PayAjoContext _repo;
    public SettlementService(PayAjoContext repo) : base(repo)
    {
      _repo = repo;
    }

    #region Settlement Service

    /// <summary>
    /// get Sms notification ..
    /// </summary>
    /// <returns></returns>
    public async Task<SmsNotificationModel> GetSmsNotification(long merchantId)
    {
      return await Task.Run(() =>
      {

        var query = from notify in _repo.Notification
                    join cust in _repo.Customer on new { cust = notify.CustomerId, merch = notify.MerchantId } equals new { cust = cust.CustomerId, merch = cust.MerchantId }
                    join merc in _repo.Merchant on notify.MerchantId equals merc.MerchantId
                    where notify.MerchantId == merchantId
                    select new { notify, cust ,merc.SmsCost };

        var model = new SmsNotificationModel();

        model.NotifyCount = query.LongCount();

        query = query.Take(100).OrderByDescending(c => c.notify.CreatedDate);

        long sumSmsCount = 0;
        decimal smsCost = 0;
        decimal merchantsmsCost = query.FirstOrDefault().SmsCost;
        if (query.Any())
        {
          foreach (var item_d in query)
          {
            var item = item_d.notify;
            sumSmsCount += item.TotalMessageSent;
            
            model.Notifications.Add(new NotificationModel()
            {
              Message = item.Message,
              Cost = merchantsmsCost,
              CreatedDate = item.CreatedDate,
              Sender = item.Sender,
              TotalMessageSent = item.TotalMessageSent,
              NotificationType = item.NotificationType,
              NotificationSystem = item.NotificationSystem,
              CustomerId = item.CustomerId,
              MerchantId = item.MerchantId,
              Recipient = item.Recipient,
              SendToUserId = item.SendToUserId,
              IsPaid = item.IsPaid,
              IsNotify = item.IsNotify,
              Id = item.Id,
              CustomerName = item_d.cust.LastName + " " + item_d.cust.FirstName
            });
          }
        }
        smsCost = sumSmsCount * merchantsmsCost;
        model.NotifyCount = sumSmsCount;
        model.SmsCost = smsCost;

        return model;
      });



    }

    #endregion
  }
}
