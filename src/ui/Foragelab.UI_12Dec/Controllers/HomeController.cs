using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Foragelab.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.apiUrl = Environment.GetEnvironmentVariable("apiUrl");
            ViewBag.apiVersion = Environment.GetEnvironmentVariable("apiVersion");
            //ViewBag.azureFilePath = Environment.GetEnvironmentVariable("AzureFilePath");

            return View();
        }

        //public IActionResult Error()
        //{
        //    ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        //    return View();
        //}
    }
}
