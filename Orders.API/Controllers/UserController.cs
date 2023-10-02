using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Categories;
using Orders.Infrastructure.Services.Users;

namespace Orders.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll(string searchKey)
        {
            var users = _userService.GetAll(searchKey);
            return Ok(GetResponse(users));
        }
        [HttpGet]
        public IActionResult Get(string id)
        {
            var user = _userService.Get(id);

            return Ok(GetResponse(user));

        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto dto)
        {
            var saveId = _userService.Create(dto);

            return Ok(GetResponse(saveId));

        }
        [HttpPut]
        public IActionResult Update(UpdateUserDto dto)
        {
            var saveId = _userService.Update(dto);

            return Ok(GetResponse(saveId));

        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var deleteId = _userService.Delete(id);

            return Ok(GetResponse(deleteId));

        }
    }
}
