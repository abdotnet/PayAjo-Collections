using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    public class CustomerBalance : BaseEntity
    {
        public long Id { get; set; }
        [Required]
        public long MerchantId { get; set; }
        //[ForeignKey("MerchantId"),]
        //public Merchant Merchant { get; set; }

        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsTechFeeChargeable { get; set; }
        public bool IsSmsFeeChargeable { get; set; }

        public DateTime TechFeeStartDate { get; set; } = DateTime.Now;
        public DateTime TechFeeEndDate { get; set; } = DateTime.Now;
    }
}
