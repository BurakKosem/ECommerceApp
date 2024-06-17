﻿using ECommerce.Application.Features.Products.Commands;
using ECommerce.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}