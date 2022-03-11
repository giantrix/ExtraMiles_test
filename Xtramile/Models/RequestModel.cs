using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xtramile.Models
{
    public class RequestModel
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string namePrefix { get; set; }
    }
}
