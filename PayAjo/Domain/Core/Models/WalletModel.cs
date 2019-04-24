using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
    public class MerchantWalletBalanceModel : Model
    {
        public long Id { get; set; }
        public long? MerchantId { get; set; }
        public MerchantModel Merchant { get; set; }
        public long UnitDepleted { get; set; }
        public long? SettingId { get; set; }
        public SettingModel Setting { get; set; }
    }

    public class AdminSmsWalletModel : Model
    {
        public long Id { get; set; }
        public long TotalPurchasedUnit { get; set; }
        public decimal TotalCostAmount { get; set; }
        public decimal ExpectedMarginReturn { get; set; }
        public bool IsActive { get; set; }
    }
}
