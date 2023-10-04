using Microsoft.AspNetCore.Mvc;
using Orders.Core.Dtos;
using Orders.Infrastructure.Services.Auth;

namespace Orders.API.Controllers
{
    public class AuthServiceController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthServiceController(IAuthService authService)
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
