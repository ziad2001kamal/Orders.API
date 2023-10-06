using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Data.Models;
using Orders.Infrastructure.Services.Categories;
using Orders.Infrastructure.Services.Resturants;

namespace Orders.API.Controllers
{
    public class ResturantController : BaseController
    {
        private readonly IResturantService _resturantService;

        public ResturantController(IResturantService resturantService)
        {
            _resturantService = resturantService;
        }
        [HttpGet]
        public IActionResult GetAll(string searchKey)
        {
            var resturants = _resturantService.Getall(searchKey);
            return Ok(GetResponse(resturants));
        }
        [HttpGet]
        public IActionResult NearMe()
        {
            var category = _resturantService.NearMe(userId);
            return Ok(GetResponse(category));

        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateResturentDto dto)
        {
            var saveId = _resturantService.Create(dto);

            return Ok(GetResponse(saveId));

        }
        //[HttpPut]
        //public IActionResult Update(UpdateCategoryDto dto)
        //{
        //    var saveId = _resturantService.Update(dto);

        //    return Ok(GetResponse(saveId));

        //}
        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var deleteId = _resturantService.Delete(id);

        //    return Ok(GetResponse(deleteId));

        //}
    }
}
