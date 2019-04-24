using Microsoft.Extensions.Configuration;
using PayAjo.Data;
using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.HangFire
{
  /// <summary>
  ///  Hangfire back ground service  ..
  /// </summary>
  public class HangFireService : IHangFireService
  {
    private readonly PayAjoContext _repo;
    private readonly ITransactionService _tranService;
    private readonly IConfiguration _config;
    private string systemEmail = string.Empty;
    public short techDay { get; set; }

    private readonly INotificationService _notify;

    /// <summary>
    /// Hang fire service constructor 
    /// </summary>
    /// <param name="repo"></param>
    /// <param name="tranService"></param>
    public HangFireService(PayAjoContext repo, ITransactionService tranService, IConfiguration config, INotificationService notify)
    {
      _repo = repo;
      _tranService = tranService;
      _config = config;
      _notify = notify;
    }

    /// <summary>
    ///  Get Customer Balance
    /// </summary>
    public IQueryable<CustomerBalance> GetCustomerBalance
    {
      get
      {
        return _repo.CustomerBalance;
      }
    }
    #region HangFire services

    /// <summary>
    ///  Date reset Job
    ///  check if the tech date is greater than 30 day should be reset
    ///  Update start and end date with  the resent date ..
    ///  set ischargeable on customer balance to true.
    /// </summary>
    /// <returns></returns>
    public Operation ResetTechDateJob()
    {
      return Operation.Create(() =>
      {
        // Customer balanace -- ischargeable ,techstartdate , techenddate 
        // Transaction --- post object ..
        // Settings ----  Amount for tech to debit  , duration to post debit 

        //var StartDate = query.StartDate.HasValue ? new DateTime(query.StartDate.Value.Year, query.StartDate.Value.Month, query.StartDate.Value.Day, 0, 0, 0) : DateTime.UtcNow;
        //var EndDate = query.EndDate.HasValue ? new DateTime(query.EndDate.Value.Year, query.EndDate.Value.Month, query.EndDate.Value.Day, 23, 59, 59) : DateTime.UtcNow;

        var settings = _repo.Setting;

        techDay = short.Parse(_config["System:TechDays"]);

        var customers = _repo.CustomerBalance.ToList();

        double totalDays = 0;
        int count_save = 0;
        //loop to check if the 
        foreach (var item in customers)
        {
          //count_save = 0;
          var merchant = settings.FirstOrDefault(c => c.MerchantId == item.MerchantId);
          if (merchant == null || !merchant.IsActive) continue;

          // if false check dates  ==> to reset to true
          if (!item.IsTechFeeChargeable && item.CurrentBalance > 0)
          {
            totalDays = Math.Round((item.TechFeeEndDate - item.TechFeeStartDate).TotalDays);
            if (totalDays == techDay)
            {
              //1. Set ischargeable to true
              item.IsTechFeeChargeable = true;

              // 2. Readjust the current date ..

              item.TechFeeStartDate = item.TechFeeEndDate.AddDays(1);
              item.TechFeeEndDate = item.TechFeeEndDate.AddDays(techDay);

              _repo.CustomerBalance.Update(item);
              // get merchant settings

              // Save changes
              count_save++;

            }
          }
        }

        if (count_save > 0) _repo.SaveChanges();
      });
    }

    /// <summary>
    ///  Anytime ischargeable is true debit customer balance and post debit transactions 
    /// </summary>
    /// <returns></returns>
    public Operation DebitTechCustomerBalanceOnIsChargeableJob()
    {
      return Operation.Create(() =>
      {
        var settings = _repo.Setting;

        int count_save = 0;
        systemEmail = _config["System:mail"];

        var system = _repo.Users.FirstOrDefault(c => c.EmailAddress == systemEmail);

        var customers = _repo.CustomerBalance.ToList();
        //loop to check if the 
        foreach (var item in customers)
        {
          if (item == null) continue;
          // count_save = 0;
          var mer_setting = settings.FirstOrDefault(c => c.MerchantId == item.MerchantId);

          if (mer_setting == null || !mer_setting.IsActive) continue;

          if (item.IsTechFeeChargeable && item.CurrentBalance > mer_setting.MinimumBalance)
          {
            item.IsTechFeeChargeable = false;
            _repo.CustomerBalance.Update(item);

            _tranService.PostTransactionForJobs(new Core.Models.TransactionJobModel()
            {
              Amount = mer_setting.TechAmount,
              CreatedBy = system != null ? system.UserId : 0,
              CustomerId = item.CustomerId,
              CreatedDate = DateTime.Now.Date,
              CustemerMerchantId = item.MerchantId,
              SystemMerchantId = system.MerchantId,
              TransactionType = TransactionType.Debit,
            }).Throw();

            count_save++;
          }
        }

        //if (count_save > 0) _repo.SaveChanges();
      });
    }

    /// <summary>
    /// Weekly Sms date reset job
    /// </summary>
    /// <returns></returns>
    public Operation WeeklySmsDateResetJob()
    {
      return Operation.Create(() =>
      {
        var settings = _repo.Setting;
        var system = _repo.Users.FirstOrDefault(c => c.EmailAddress == systemEmail);
        var customers = _repo.Customer;

        techDay = short.Parse(_config["System:SmsDays"]);

        var customer_bal = _repo.CustomerBalance.ToList();

        double totalDays = 0;
        int count_save = 0;
        Customer customer = null;
        //loop to check if the 
        foreach (var item in customer_bal)
        {
          //count_save = 0;
          var merchant = settings.FirstOrDefault(c => c.MerchantId == item.MerchantId);
          if (merchant == null || !merchant.IsActive) continue;
          customer = customers.FirstOrDefault(c => c.CustomerId == item.CustomerId);
          if (customer == null) continue;

          // if false check dates  ==> to reset to true
          if (!item.IsTechFeeChargeable && item.CurrentBalance > merchant.MinimumBalance && customer.IsSmsNotify)
          {
            totalDays = Math.Round((customer.SmsEndDate - customer.SmsStartDate).TotalDays);
            if (totalDays == techDay)
            {
              //1. Set ischargeable to true
              item.IsSmsFeeChargeable = true;

              // 2. Readjust the current date ..
              customer.SmsStartDate = customer.SmsEndDate.AddDays(2); // 2days for weekend
              customer.SmsEndDate = item.TechFeeEndDate.AddDays(techDay);

              _repo.Customer.Update(customer);
              _repo.CustomerBalance.Update(item);
              // get merchant settings

              // Save changes
              count_save++;

            }
          }
        }

        if (count_save > 0) _repo.SaveChanges();

      });
    }

    /// <summary>
    ///  Debit Customer balance and post debit to transaction
    ///  For weekly sms
    ///  Send the actual Sms..
    /// </summary>
    /// <returns></returns>
    public Operation SendWeeklySmsJob()
    {
      return Operation.Create(() =>
      {

        var setting = _repo.Setting;

        systemEmail = _config["System:mail"];

        var system = _repo.Users.FirstOrDefault(c => c.EmailAddress == systemEmail);

        var customer = _repo.Customer;

        var customer_bal = _repo.CustomerBalance.ToList();

        bool isNotify = false;
        foreach (var item in customer_bal)
        {
          var setin = setting.FirstOrDefault(c => c.MerchantId == item.MerchantId);

          // check duration from customer table sms duration  and reset date every 1 week
          isNotify = customer.FirstOrDefault(c => c.CustomerId == item.CustomerId).IsSmsNotify;

          if (item.IsSmsFeeChargeable && isNotify)
          {
            item.IsSmsFeeChargeable = false;
            _repo.CustomerBalance.Update(item);
            // Debit customer balance and transaction

            _tranService.PostTransactionForJobs(new Core.Models.TransactionJobModel()
            {
              Amount = setin.SmsAmount,
              CreatedBy = system != null ? system.UserId : 0,
              CustomerId = item.CustomerId,
              CreatedDate = DateTime.Now.Date,
              CustemerMerchantId = item.MerchantId,
              SystemMerchantId = system.MerchantId,
              TransactionType = TransactionType.Debit,
            }).Throw();

            // Send Sms..
            _notify.SendSmsKudiJob();
          }

        }

      });
    }

    public Operation PushSms()
    {
      return Operation.Create(() =>
      {
        _notify.SendSmsKudiJob().Throw();
        Log.Information("got to push sms");
      });
    }

    /// <summary>
    /// Send Sms HangFire Notification ...
    /// </summary>
    /// <returns></returns>
    public Operation SendSmsHangFireNotification()
    {
      return Operation.Create(() =>
      {
        var merchants = _repo.Merchant.Where(c => c.MerchantId > 2).ToList();
        foreach (var item in merchants)
        {
          _notify.SendSmsNotificationAsync(item.MerchantId);
        }

      });
    }
    #endregion

  }
}
