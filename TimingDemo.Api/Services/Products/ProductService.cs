using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimingDemo.Api.Data;
using TimingDemo.Api.DTOs.Products;
using TimingDemo.Api.Models;
using TimingDemo.Api.Paged;

namespace TimingDemo.Api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<ProductDto>> GetAllAsync(
            int pageNumber,
            int pageSize,
            int? categoryId,
            CancellationToken ct)
        {
            var query = _context.Products
                .AsNoTracking();

            if (categoryId.HasValue)
            {
                query = query.Where(
                    p => p.CategoryId == categoryId.Value);
            }

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .OrderByDescending(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .ToListAsync(ct);

            return new PagedResponse<ProductDto>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(
                    totalCount / (double)pageSize)
            };
        }

        public async Task<ProductDto?> GetByIdAsync(
            int id,
            CancellationToken ct)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefaultAsync(ct);
        }

        public async Task<ProductDto?> CreateAsync(
            CreateProductRequest request,
            CancellationToken ct)
        {
            var categoryName = await _context.Categories
                .AsNoTracking()
                .Where(c => c.Id == request.CategoryId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync(ct);

            if (categoryName is null)
            {
                return null;
            }

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync(ct);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                CategoryName = categoryName
            };
        }
    }
}
