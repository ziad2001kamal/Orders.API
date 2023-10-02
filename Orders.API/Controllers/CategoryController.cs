using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Infrastructure.Services.Categories;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll(string searchKey)
        {
            var categories = _categoryService.GetAll(searchKey);
            return Ok(GetResponse(categories));
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);

            return Ok(GetResponse(category));

        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDto dto)
        {
            var saveId = _categoryService.Create(dto);

            return Ok(GetResponse(saveId));

        }
        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var saveId = _categoryService.Update(dto);

            return Ok(GetResponse(saveId));

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteId = _categoryService.Delete(id);

            return Ok(GetResponse(deleteId));

        }
    }
}
