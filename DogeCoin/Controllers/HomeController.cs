using DogeCoin.Models;
using DogeCoin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DogeCoin.Controllers
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
            var dogeToUsdResponse = DogeToUsdService.GetRequestContent();
            var sochainResponseModel = JsonConvert.DeserializeObject<SochainResponseModel>(dogeToUsdResponse);
            return View();
        }

        [HttpGet]
        public ActionResult<decimal> dogeToUsd()
        {
            try
            {
                var dogeToUsdResponse = DogeToUsdService.GetRequestContent();
                var sochainResponseModel = JsonConvert.DeserializeObject<SochainResponseModel>(dogeToUsdResponse);
                var x = sochainResponseModel.data.prices.Where(x => x.exchange == "binance").Select(s => s.price).FirstOrDefault();
                return Ok(decimal.Parse(x));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
