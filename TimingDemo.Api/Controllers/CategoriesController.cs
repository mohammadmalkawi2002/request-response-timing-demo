using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimingDemo.Api.DTOs.Categories;
using TimingDemo.Api.Services.Categories;

namespace TimingDemo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryRequest request)
        {
            var category = await _categoryService.CreateAsync(request);
            
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }
    }
}
