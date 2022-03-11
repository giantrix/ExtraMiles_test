using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xtramile.Logic;
using Xtramile.Models;

namespace Xtramile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HomeLogic hmLogic;
        IConfiguration config;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            hmLogic = new HomeLogic(configuration);
        }

        public IActionResult Index()
        {

            RequestModel req = new RequestModel();
            req.Limit = 10;
            req.Offset = 0;
            req.namePrefix = "";
            List<CountryModel> lsCountries = hmLogic.GetCountries(req);

            return View(lsCountries);
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

        public List<SelectListItem> Countries()
        {
            List<SelectListItem> phy = new List<SelectListItem>();

            RequestModel req = new RequestModel();
            req.Limit = 10;
            req.Offset = 0;
            req.namePrefix = "";
            List<CountryModel> lsCountries = hmLogic.GetCountries(req);
            if (lsCountries.Count() > 0)
            {
                foreach (var v in lsCountries)
                {
                    phy.Add(new SelectListItem { Text = v.Name , Value = v.Code });
                }
            }
            return phy;
        }

        [AcceptVerbs("Get")]
        public List<CityModel> LoadCitiesByCountry(string countryCode)
        {
            //Your Code For Getting Physicans Goes Here
            List<CityModel> res = new List<CityModel>();
            RequestModel param = new RequestModel();
            param.Limit = 10;
            param.Offset = 00;
            param.namePrefix = countryCode;

            res = hmLogic.GetCities(param);

            return res;
            
        }

        [AcceptVerbs("Get")]
        public WeatherResponseModel LoadCitiesDetail(string cityName)
        {
            //Your Code For Getting Physicans Goes Here
            WeatherResponseModel res = new WeatherResponseModel();
            RequestModel param = new RequestModel();
            param.Limit = 10;
            param.Offset = 00;
            param.namePrefix = cityName;

            res = hmLogic.GetCityDetailByName(param);

            return res;

        }
    }
}
