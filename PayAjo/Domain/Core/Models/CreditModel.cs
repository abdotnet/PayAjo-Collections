using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class CreditModel
  {
    public decimal TotalDebitWeekly { get; set; }
    public decimal TotalCreditWeekly { get; set; }
    public decimal TotalCreditMonthly { get; set; }
  }
}
