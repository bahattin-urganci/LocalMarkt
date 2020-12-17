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
    public class GetProductsByCategory : IRequest<List<ProductDTO>>
    {
        public int CategoryId { get; set; }
    }
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategory, List<ProductDTO>>
    {
        private readonly LocalMarktDbContext _db;
        private readonly IMapper _mapper;

        public GetProductsByCategoryHandler(LocalMarktDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Handle(GetProductsByCategory request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<ProductDTO>>(await _db.Products.Where(x => x.CategoryId == request.CategoryId).ToListAsync());
        }
    }
}
