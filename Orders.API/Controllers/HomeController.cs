using Microsoft.AspNetCore.Mvc;
//using Orders.API.Models;
using System.Diagnostics;

namespace Orders.API.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return Ok("Welcome to API Project");
        }


    }
}