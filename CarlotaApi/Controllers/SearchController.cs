using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace CarlotaApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string name="")
        {
            // Handles the string that call Hipo Labs API, default string represents All universities in Brazil in a JSON.
            string stringTeste;

            if (String.IsNullOrEmpty(name))
            {
               stringTeste = "http://universities.hipolabs.com/search?country=brazil";
            }
            else
            {
                stringTeste = $"http://universities.hipolabs.com/search?name={name.Replace(" ", "%20")}&country=brazil";
            }

            // Creatig WebClient object to return JSON object as a string
            WebClient webClient = new WebClient();
            var retorno = webClient.DownloadString(stringTeste);

            return Ok(retorno);
        }
    }
}
