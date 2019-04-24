using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class Transaction : BaseEntity
  {
    public long Id { get; set; }
    public string TransactionNo { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public string TransactionCode { get; set; }
    public string TransactionChannel { get; set; }
    public long MerchantId { get; set; }
    [ForeignKey("MerchantId")]
    public Merchant Merchant { get; set; }

    public long? CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public bool IsNotified { get; set; }

    public long? CollectionTypeId { get; set; }
    [ForeignKey("CollectionTypeId")]
    public CollectionType CollectionType { get; set; }
    // 
    /// <summary>
    ///helps to hold same code for settlement between other merchant and admin merchant 
    /// </summary>
    public string TransactionMapCode { get; set; }
    public string Message { get; set; }

  }

  public class TransactionLog : BaseEntity
  {
    public long Id { get; set; }
    public string TransactionNo { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public string TransactionCode { get; set; }
    public long MerchantId { get; set; }
    [ForeignKey("MerchantId")]
    public Merchant Merchant { get; set; }

    public long? CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    public bool IsNotified { get; set; }

    public string TransactionChannel { get; set; }
    public long? CollectionTypeId { get; set; }
    [ForeignKey("CollectionTypeId")]
    public CollectionType CollectionType { get; set; }
    // 
    /// <summary>
    ///helps to hold same code for settlement between other merchant and admin merchant 
    /// </summary>
    public string TransactionMapCode { get; set; }
    public string Message { get; set; }
    public bool IsApproved { get; set; }
  }
}
