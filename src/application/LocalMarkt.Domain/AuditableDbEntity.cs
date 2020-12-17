using System;
using System.Collections.Generic;
using System.Text;

namespace LocalMarkt.Domain
{
    public class AuditableDbEntity : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
