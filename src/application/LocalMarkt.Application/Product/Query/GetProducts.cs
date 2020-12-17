using AutoMapper;
using LocalMarkt.Model.Product;
using LocalMarkt.Persistence.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalMarkt.Application.Product.Query
{
    public class GetProducts : IRequest<List<ProductDTO>>
    {
        
    }
    public class GetProductsHandler : IRequestHandler<GetProducts, List<ProductDTO>>
    {
        private readonly LocalMarktDbContext _db;
        private readonly IMapper _mapper;

        public GetProductsHandler(LocalMarktDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }
}
