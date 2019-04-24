using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Enum
{
  /// <summary>
  /// Withdrawal Status
  /// </summary>
  public enum WithdrawalStatus
  {
    /// <summary>
    /// Pending
    /// </summary>
    Pending = 0,
    /// <summary>
    /// Approved
    /// </summary>
    Approved = 1,
    /// <summary>
    /// Paid
    /// </summary>
    Paid = 2
  }
}
