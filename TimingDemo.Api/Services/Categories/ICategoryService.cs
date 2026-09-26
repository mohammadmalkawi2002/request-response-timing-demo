using System.Collections.Generic;
using System.Threading.Tasks;
using TimingDemo.Api.DTOs.Categories;

namespace TimingDemo.Api.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CreateCategoryRequest request);
    }
}
