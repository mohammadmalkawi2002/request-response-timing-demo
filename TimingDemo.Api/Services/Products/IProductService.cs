using System.Collections.Generic;
using System.Threading.Tasks;
using TimingDemo.Api.DTOs.Products;
using TimingDemo.Api.Paged;

namespace TimingDemo.Api.Services.Products
{
    public interface IProductService
    {
        Task<PagedResponse<ProductDto>> GetAllAsync(
            int pageNumber,
            int pageSize,
            int? categoryId,
            CancellationToken ct);

        Task<ProductDto?> GetByIdAsync(
            int id,
            CancellationToken ct);

        Task<ProductDto?> CreateAsync(
            CreateProductRequest request,
            CancellationToken ct);
    }
}
