using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    /// <summary>
    /// To use this table two merchant must be created @ a time and the code is use to 
    /// tire them together  .. 
    /// </summary>
    public class MerchantBalanceSetting
    {
        public long Id { get; set; }
        public long MerchantId { get; set; }
        [ForeignKey("MerchantId")]
        public Merchant Merchant { get; set; }
        public decimal Amount { get; set; }
        /// <summary>
        /// Code to map two merchant together   ..  
        /// </summary>
        public string MerchantMapCode { get; set; }
    }
}
