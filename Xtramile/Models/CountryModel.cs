using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xtramile.Models
{
    public class CountryModel
    {
        public string Code { get; set; }
        public List<string> CurrencyCodes { get; set; }
        public string Name { get; set; }
        public string WikiDataId { get; set; }
    }

   
}
