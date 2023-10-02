using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Orders.Core.ViewModels;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected async Task<APIResponseViewModel> GetResponse(object data)
        {
            var response = new APIResponseViewModel(true, "Done", data);

            return response;
        }
    }

}
