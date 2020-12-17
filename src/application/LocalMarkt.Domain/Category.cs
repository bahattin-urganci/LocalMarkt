using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LocalMarkt.Domain
{
    public class Category : AuditableDbEntity
    {
        public string CategoryName { get; set; }
        
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]        
        public virtual Category ParentCategory { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
