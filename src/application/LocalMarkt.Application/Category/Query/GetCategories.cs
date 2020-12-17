using AutoMapper;
using LocalMarkt.Model.Category;
using LocalMarkt.Persistence.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalMarkt.Application.Category.Query
{
    public class GetCategories :IRequest<List<CategoryDTO>>
    {
        public int? CategoryId { get; set; }
    }

    public class GetCategoriesHandler : IRequestHandler<GetCategories, List<CategoryDTO>>
    {
        private readonly LocalMarktDbContext _db;
        private IMapper _mapper;

        public GetCategoriesHandler(LocalMarktDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Handle(GetCategories request, CancellationToken cancellationToken)
        {
            var query = _db.Categories.AsQueryable();
            if (request.CategoryId.HasValue)
            {
                query = query.Where(x => x.Id == request.CategoryId.Value);
            }

            return _mapper.Map<List<CategoryDTO>>(await query.ToListAsync());
        }
    }
}
