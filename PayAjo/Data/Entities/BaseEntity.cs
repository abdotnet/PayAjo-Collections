using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; } 
        public long CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.UtcNow;
        public long ModifiedBy { get; set; }
    }
}
