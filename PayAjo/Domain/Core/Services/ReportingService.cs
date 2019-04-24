using PayAjo.Data;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
  public class ReportingService : Service, IReportingService
  {

    private readonly PayAjoContext _repo;
    public ReportingService(PayAjoContext repo) : base(repo)
    {
      _repo = repo;
    }

    #region reporting  Service
    /// <summary>
    /// Dashboard information
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Operation<DashboardModel> GetDashboard([Required]long userId)
    {
      return Operation.Create(() =>
      {
        var model = new DashboardModel();
        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User merchant not found");

        var mer_bal = _repo.MerchantBalance.FirstOrDefault(c => c.MerchantId == user.MerchantId);
        model.TotalMerchantBalance = mer_bal ==  null? 0: mer_bal.Amount;

        model.LastTenTransaction = (from t in _repo.Transaction
                                    join c in _repo.Customer on t.CustomerId equals c.CustomerId
                                    where t.MerchantId == user.MerchantId
                                    orderby t.Id descending
                                    select new TransactionReponseModel()
                                    {
                                      Id = t.Id,
                                      Amount = t.Amount,
                                      CreatedDate = t.CreatedDate,
                                      TransactionMessage = t.Message,
                                      TransactionType = t.TransactionType,
                                      TransactionNo = t.TransactionNo,
                                      Customer = new CustomerModel()
                                      {
                                        LastName = c.LastName,
                                        CustomerCode = c.CustomerCode,
                                        FirstName = c.FirstName
                                      }
                                    }).Take(10).ToList();

        model.LastTenWithdrawal = (from w in _repo.Withdrawal
                                   join c in _repo.Customer on w.CustomerId equals c.CustomerId
                                   where w.MerchantId == user.MerchantId
                                   orderby w.Id descending
                                   select new WithdrawalResponseModel()
                                   {
                                     Id = w.Id,
                                     Amount = w.Amount,
                                     CreatedDate = w.CreatedDate,
                                     Message = w.Message,
                                     WithdrawalStatus = w.WithdrawalStatus,
                                     Customer = new CustomerModel()
                                     {
                                       LastName = c.LastName,
                                       FirstName = c.FirstName,
                                       CustomerCode = c.CustomerCode
                                     }
                                   }).Take(10).ToList();

        model.TotalActiveCustomers = _repo.Customer.Where(c => c.MerchantId == user.MerchantId && c.IsActive).Count();

        var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
        var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);

        model.TotalCustomerToday = _repo.CustomerBalance.Where(c=> c.ModifiedDate >= endDate && c.ModifiedDate <= startDate && c.MerchantId == user.MerchantId).LongCount();

        model.TotalDailyCredit = _repo.Transaction.Where(c => c.CreatedDate >= endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit && c.MerchantId == user.MerchantId).Sum(c => c.Amount);
        model.TotalDailyDebit = _repo.Transaction.Where(c => c.CreatedDate >= endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Debit && c.MerchantId == user.MerchantId).Sum(c => c.Amount);

        var _endDate = endDate.AddDays(-7);

        model.TotalWeeklyCredit = _repo.Transaction.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit && c.MerchantId == user.MerchantId).Sum(c => c.Amount);
        model.TotalWeeklyDebit = _repo.Transaction.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Debit && c.MerchantId == user.MerchantId).Sum(c => c.Amount);

        _endDate = endDate.AddDays(-30);
        model.TotalMonthlyCredit = _repo.Transaction.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit && c.MerchantId == user.MerchantId).Sum(c => c.Amount);
        model.TotalMonthlyDebit = _repo.Transaction.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Debit && c.MerchantId == user.MerchantId).Sum(c => c.Amount);

        return model;
      });
    }
    #endregion

  }
}
