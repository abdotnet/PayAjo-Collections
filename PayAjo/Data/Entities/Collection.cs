using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    public class Collection : BaseEntity
    {
        public long Id { get; set; }
        public long? MerchantId { get; set; }
        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }
        public long? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
        public string ReasonForCollection { get; set; }
        public bool IsNotify { get; set; }
        public string CollectionCode { get; set; }
        public bool IsCancelled { get; set; }
    }
}
