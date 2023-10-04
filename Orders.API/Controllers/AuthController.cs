using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Auth;

namespace Orders.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            return Ok(GetResponse(await _authService.Login(dto)));
        }
    }
}
