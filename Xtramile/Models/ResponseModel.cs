using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xtramile.Models
{

    public class RespnseModel<T>
    {
        public List<T> Data { get; set; }
        public MetaData Metadata { get; set; }
    }
    public class MetaData
    {
        public string currentOffset { get; set; }
        public string totalCount { get; set; }
    }

    public class WeatherResponseModel
    {
        public Coord coord { get; set; }

        public List<Weather> weather { get; set; }
        public string Base{get;set;}

        public Main main { get; set; }
        public string visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }

        public string dt { get; set; }
        public Sys sys { get; set; }


        public string timezone { get; set; }

        public string id { get; set; }
        public string name { get; set; }
        public string cod { get; set; }

    }
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    public class Weather
    {

        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    public class Clouds
    {

        public double all { get; set; }
    }
    public class Sys
    {
        public string type { get; set; }
        public string id { get; set; }
        public string country { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    
}
