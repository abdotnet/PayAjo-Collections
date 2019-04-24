using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
    public class CollectionModel : Model
    {
        public long Id { get; set; }
        public long? MerchantId { get; set; }
        public MerchantModel Merchant { get; set; }
        public long? CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
        public string ReasonForCollection { get; set; }
        public bool IsNotify { get; set; }
        public string CollectionCode { get; set; }
        public CollectionModel()
        {
            CollectionCode = GetCollectionCode().Result;
        }
    }
    public class CollectionTypeModel : Model
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
