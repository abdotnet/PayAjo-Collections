using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class MerchantAgentBalance : BaseEntity
  {
    public long Id { get; set; }

    public long MerchantId { get; set; }
    [ForeignKey("MerchantId")]
    public Merchant Merchant { get; set; }
    public decimal CurrentBalance { get; set; }

    [Required]
    public long AgentId { get; set; }
  }
}
