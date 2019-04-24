using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
    public class AuditTrail : BaseEntity
    {
        public long Id { get; set; }
        public string IPAddress { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
