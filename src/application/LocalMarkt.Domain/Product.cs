using System;
using System.Collections.Generic;
using System.Text;

namespace LocalMarkt.Domain
{
    public class Product : AuditableDbEntity
    {
        public string Name { get; set; }
    }
}
