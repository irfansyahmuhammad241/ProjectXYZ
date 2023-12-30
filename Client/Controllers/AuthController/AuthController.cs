using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Client.Controllers.AuthController
{
    public class AuthController : Controller
    {
        [Route("Auth/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Auth/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

    }
}
