using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface IReportingService
  {
    Operation<DashboardModel> GetDashboard(long userId);
  }
}
