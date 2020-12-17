using AutoMapper;
using LocalMarkt.Model.Product;
using LocalMarkt.Persistence.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalMarkt.Application.Product.Command
{
    public class AddOrUpdateProduct : IRequest<ProductDTO>
    {
        public ProductDTO Product { get; set; }
    }
    public class AddOrUpdateProductHandler : IRequestHandler<AddOrUpdateProduct, ProductDTO>
    {
        private readonly LocalMarktDbContext _db;
        private readonly IMapper _mapper;

        public AddOrUpdateProductHandler(LocalMarktDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(AddOrUpdateProduct request, CancellationToken cancellationToken)
        {
            var product = request.Product;
            Domain.Product data = null;
            if (product.Id > 0)
            {
                var entry = _db.Products.Find(product.Id);
                _db.Entry(entry).CurrentValues.SetValues(product);
            }
            else
            {
                data = _mapper.Map<Domain.Product>(product);
                _db.Products.Add(data);
            }
            await _db.SaveChangesAsync();
            product.Id = data.Id;
            return product;
        }
    }
}
