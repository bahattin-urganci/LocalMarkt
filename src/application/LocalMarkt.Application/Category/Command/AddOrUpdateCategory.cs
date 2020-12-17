using AutoMapper;
using LocalMarkt.Model.Category;
using LocalMarkt.Persistence.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalMarkt.Application.Category.Command
{
    public class AddOrUpdateCategory : IRequest<int>
    {
        public CategoryDTO Category { get; set; }
    }
    public class AddOrUpdateCategoryHandler : IRequestHandler<AddOrUpdateCategory, int>
    {
        private readonly LocalMarktDbContext _db;
        private readonly IMapper _mapper;
        public AddOrUpdateCategoryHandler(LocalMarktDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddOrUpdateCategory request, CancellationToken cancellationToken)
        {
            if (request.Category.Id > 0)
            {
                var entry = _db.Categories.Find(request.Category.Id);
                if (entry == null)
                {
                    throw new Exception("The category can't find");
                }
                _db.Entry(entry).CurrentValues.SetValues(request.Category);
            }
            else
            {
                var record = _mapper.Map<Domain.Category>(request.Category);
                _db.Categories.Add(record);
                request.Category.Id = record.Id;
            }

            await _db.SaveChangesAsync();
            return request.Category.Id;
        }
    }
}
