using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    public class MerchantWalletBalance:BaseEntity
    {
        public long Id { get; set; }
        public long? MerchantId { get; set; }
        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }
        public long UnitDepleted { get; set; }
        public long? SettingId { get; set; }
        [ForeignKey("SettingId")]
        public Setting Setting { get; set; }
    }

    public class AdminSmsWallet  : BaseEntity
    {
        public long Id { get; set; }
        public long  TotalPurchasedUnit{ get; set; }
        public decimal TotalCostAmount { get; set; }
        public decimal ExpectedMarginReturn { get; set; }
        public bool IsActive { get; set; }
    }
}
