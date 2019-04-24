using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class DashboardModel
  {
    public decimal TotalMerchantBalance { get; set; }
    public decimal TotalDailyCredit { get; set; }
    public decimal TotalWeeklyCredit { get; set; }
    public decimal TotalMonthlyCredit { get; set; }
    public decimal TotalDailyDebit { get; set; }
    public decimal TotalWeeklyDebit { get; set; }
    public decimal TotalMonthlyDebit { get; set; }
    public long TotalActiveCustomers { get; set; }
    public long TotalCustomerToday { get; set; }
    public List<TransactionReponseModel> LastTenTransaction { get; set; } = new List<TransactionReponseModel>();
    public List<WithdrawalResponseModel> LastTenWithdrawal { get; set; } = new List<WithdrawalResponseModel>();
  }

}
