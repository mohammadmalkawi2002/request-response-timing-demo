using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimingDemo.Api.DTOs.Products;
using TimingDemo.Api.Paged;
using TimingDemo.Api.Services.Products;

namespace TimingDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<ProductDto>>> GetProducts(
           [FromQuery] int pageNumber = 1,
           [FromQuery] int pageSize = 10,
           [FromQuery] int? categoryId = null,
           CancellationToken ct = default)
        {
            if (pageNumber < 1 || pageSize < 1 || pageSize > 50)
            {
                return BadRequest(
                    "Page number must be greater than zero and page size must be between 1 and 50.");
            }

            var result = await _productService.GetAllAsync(
                pageNumber,
                pageSize,
                categoryId,
                ct);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(
            int id,
            CancellationToken ct = default)
        {
            var product = await _productService.GetByIdAsync(id, ct);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(
            CreateProductRequest request,
            CancellationToken ct = default)
        {
            var product = await _productService.CreateAsync(request, ct);

            if (product is null)
            {
                return BadRequest(
                    $"Category with Id {request.CategoryId} does not exist.");
            }

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.Id },
                product);
        }
    }
}
    

