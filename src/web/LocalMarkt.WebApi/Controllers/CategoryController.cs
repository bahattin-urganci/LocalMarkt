using LocalMarkt.Application.Category.Command;
using LocalMarkt.Application.Category.Query;
using LocalMarkt.Model.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarkt.WebApi.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] int? categoryId)
        {
            return Ok(await _mediator.Send(new GetCategories { CategoryId = categoryId }));
        }
        [HttpPost]
        public async Task<IActionResult> SaveCategory([FromBody] CategoryDTO category) => Ok(await _mediator.Send(new AddOrUpdateCategory { Category=category}));
    }
}
