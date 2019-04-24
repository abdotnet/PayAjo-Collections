using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    public class CollectionType : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

    }
}
