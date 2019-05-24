using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DIPLOMA.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }

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
                ["Администратор"] = HttpContext.User.IsInRole("Администратор"),
                ["Город"] = CurrentUser.Result.City,
                ["Квалификация"] = CurrentUser.Result.Qualifications
            };

        [Authorize]
        public async Task<IActionResult> UserProps()
        {
            return View(await CurrentUser);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps(
            [Required]Cities city,
            [Required]QualificationLevels qualifications)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await CurrentUser;
                user.City = city;
                user.Qualifications = qualifications;
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(await CurrentUser);
        }

        private Task<AppUser> CurrentUser =>
            userManager.FindByNameAsync(HttpContext.User.Identity.Name);

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
