using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

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
        
        [HttpGet]
        public IActionResult Result(string? name)
        {
            // String that call CarlotaAPI and gets the JSON object as string to be processed in Result View
            var stringUniversidades = "https://localhost:5443/search";

            if (name != null)
            {
                stringUniversidades = $"https://localhost:5443/search?name={name}";
            }

            // * -----------------------------------------------------------------------------------------------------------------------*
            // NOT RECOMMENDED, USED ONLY TO BYPASS SECURITY PROTOCOLS FOR TEST PURPOSES. RUN THIS CODE ONLY IN LOCAL OR DEV ENVIRONMENTS
            // * -----------------------------------------------------------------------------------------------------------------------*
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors) { return true; };

            // Creating WebClient object to handle return from CarlotaAPI
            WebClient webClient = new WebClient();
            var retorno = webClient.DownloadString(stringUniversidades);

            // Deserializing CarlotaAPI JSON return and adding the JSON object to Result.cshtml ViewData["UniversityJson"]
            dynamic parseJson = JsonConvert.DeserializeObject(retorno);

            ViewData["UniversityJson"] = parseJson;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
