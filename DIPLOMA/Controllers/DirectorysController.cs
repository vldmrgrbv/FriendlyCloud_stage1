using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DIPLOMA.Models;
using System.ComponentModel.DataAnnotations;

namespace DIPLOMA.Controllers
{
    public class DirectorysController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Clients()
        {
            return View();
        }
    }
}
