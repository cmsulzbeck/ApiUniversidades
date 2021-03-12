using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarlotaApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string name="")
        {
            string stringTeste;

            if (String.IsNullOrEmpty(name))
            {
               stringTeste = "http://universities.hipolabs.com/search?country=brazil";
            }
            else
            {
                stringTeste = $"http://universities.hipolabs.com/search?name={name.Replace(" ", "%20")}&country=brazil";
            }

            WebClient webClient = new WebClient();
            var retorno = webClient.DownloadString(stringTeste);

            return Ok(retorno);
        }
    }
}
