using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {

        protected async Task<APIResponseViewModel> GetResponse(object data)
        {
            var response = new APIResponseViewModel(true, "Done", data);

            return response;
        }

    }

}
