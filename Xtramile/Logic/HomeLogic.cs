using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xtramile.Common;
using Xtramile.Models;
using static Xtramile.Common.RestHelper;

namespace Xtramile.Logic
{
    public class HomeLogic
    {
        RestHelper restHelper;

        private readonly IConfiguration _config;

        public HomeLogic(IConfiguration config)
        {
            _config = config;
        }
        public List<CountryModel> GetCountries(RequestModel request=null)
        {
            
            List<CountryModel> lsCountires = new List<CountryModel>();
            string urlEndpoint = _config.GetValue<string>("APIURLData")+ _config.GetValue<string>("APIURLCountries");
            if (request != null)
                urlEndpoint = urlEndpoint + string.Format("?limit={0}&offset={1}&namePrefix{2}", request.Limit, request.Offset, request.namePrefix);

            RespnseModel<CountryModel> response = SendRequest<RespnseModel<CountryModel>>(RequestType.Get, urlEndpoint, request);
            lsCountires = response.Data;
            return lsCountires;
        }

        public List<CityModel> GetCities(RequestModel request = null)
        {

            List<CityModel> lsCountires = new List<CityModel>();
            try
            {
                string urlEndpoint = _config.GetValue<string>("APIURLData") + _config.GetValue<string>("APIURLCities");

                if (request != null)
                    urlEndpoint = urlEndpoint + string.Format("?limit={0}&offset={1}&countryIds={2}", request.Limit, request.Offset, request.namePrefix);

                RespnseModel<CityModel> response = SendRequest<RespnseModel<CityModel>>(RequestType.Get, urlEndpoint, "");
                lsCountires = response.Data;

            }
            catch(Exception ex)
            {
                throw new Exception("Failed on get cities", ex.InnerException);
            }
            if (lsCountires.Count < 1)
                throw new Exception("cities not listed");
            return lsCountires;
        }

        public WeatherResponseModel GetCityDetailByName(RequestModel request = null)
        {

            WeatherResponseModel lsCountires = new WeatherResponseModel();
            string urlEndpoint = _config.GetValue<string>("APIURLWeather") ;

            if (request != null)
                urlEndpoint = urlEndpoint + string.Format("?q={0}&appid={1}", request.namePrefix, _config.GetValue<string>("AppId"));

            var response = SendRequest<WeatherResponseModel>(RequestType.Get, urlEndpoint, "");
            lsCountires = response;
            return lsCountires;
        }
    }
}
