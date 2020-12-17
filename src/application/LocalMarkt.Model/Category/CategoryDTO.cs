using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalMarkt.Model.Category
{
    [AutoMap(typeof(Domain.Category), ReverseMap = true)]
    public class CategoryDTO : BaseDTO
    {
        public string CategoryName { get; set; }

        public int? ParentId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
