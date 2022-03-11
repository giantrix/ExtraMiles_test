using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xtramile.Models
{
    public class CityModel
    {
        public string id { get; set; }
        public string wikiDataId { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionCode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string population { get; set; }
    }

    
}
