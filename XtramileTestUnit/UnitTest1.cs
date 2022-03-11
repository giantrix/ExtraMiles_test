using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xtramile.Logic;
using Xtramile.Models;
using Xunit;

namespace XtramileTestUnit
{
    public class UnitTest1
    {
        private HomeLogic hmLogic;
        
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Test2()
        {
            //getting list data country
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            HomeLogic hmLogic = new HomeLogic(config);
            RequestModel req = new RequestModel();
            req.Limit = 10;
            req.Offset = 0;
            req.namePrefix = "";
            List<CountryModel> lsCountries = hmLogic.GetCountries(req);

            Assert.NotEmpty(lsCountries);
        }

        [Fact]
        public void Test3()
        {
            //getting list data Cities by vatikan(VA)
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            HomeLogic hmLogic = new HomeLogic(config);
            RequestModel req = new RequestModel();
            req.Limit = 10;
            req.Offset = 0;
            req.namePrefix = "VA";
            List<CityModel> lsItems = hmLogic.GetCities(req);

            Assert.Empty(lsItems);
        }

        [Fact]
        public void Test4()
        {
            //getting list data Cities by vatikan(VA)
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            HomeLogic hmLogic = new HomeLogic(config);
            RequestModel req = new RequestModel();
            req.Limit = 10;
            req.Offset = 0;
            req.namePrefix = "VA";

            Assert.Throws<Exception>(() => hmLogic.GetCities(req));
        }

        [Fact]
        public void Test5()
        {
            //getting data Cities Adama
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            HomeLogic hmLogic = new HomeLogic(config);
            RequestModel req = new RequestModel();
            req.Limit = 10;
            req.Offset = 0;
            req.namePrefix = "Adama";
            WeatherResponseModel lsCountires = hmLogic.GetCityDetailByName(req);
            Assert.NotNull(lsCountires);
        }
    }
}
