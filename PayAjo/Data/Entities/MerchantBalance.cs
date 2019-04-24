using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    public class MerchantBalance : BaseEntity
    {
        public long Id { get; set; }
        public long MerchantId { get; set; }
        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }
        public decimal Amount { get; set; }
    }
}
