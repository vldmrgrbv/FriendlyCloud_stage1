using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Authorization;

namespace DIPLOMA.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index() => View(GetData(nameof(Index)));

        [Authorize(Roles = "Администратор")]
        public IActionResult OtherAction() => View("Index",
            GetData(nameof(OtherAction)));

        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object>
            {
                ["Пользователь"] = HttpContext.User.Identity.Name,
                ["Авторизация"] = HttpContext.User.Identity.IsAuthenticated,
                ["Администратор"] = HttpContext.User.IsInRole("Администратор")
            };


        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
