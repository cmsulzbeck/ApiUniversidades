using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Use this area to provide additional information";

            return View();
        }

        public IActionResult Result(string? name)
        {
            var stringTeste = "http://universities.hipolabs.com/search?country=brazil";

            WebClient webClient = new WebClient();
            var retorno = webClient.DownloadString(stringTeste);

            dynamic parseJson =  JsonConvert.DeserializeObject(retorno);
            Console.WriteLine(parseJson);

            ViewData["Message"] = parseJson;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
