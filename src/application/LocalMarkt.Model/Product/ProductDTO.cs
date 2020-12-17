using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalMarkt.Model.Product
{
    [AutoMap(typeof(LocalMarkt.Domain.Product), ReverseMap = true)]
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
    }
}
