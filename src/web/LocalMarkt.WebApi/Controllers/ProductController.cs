using LocalMarkt.Application.Product.Command;
using LocalMarkt.Application.Product.Query;
using LocalMarkt.Model.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarkt.WebApi.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsByCategory([FromQuery] int categoryId) => Ok(await _mediator.Send(new GetProductsByCategory { CategoryId = categoryId }));
        [HttpGet]
        public async Task<IActionResult> Products() => Ok(await _mediator.Send(new GetProducts()));
        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] ProductDTO product) => Ok(await _mediator.Send(new AddOrUpdateProduct { Product = product }));
    }
}
