using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testwebapi.Models
{
    public class ResponseJSON
    {
        public string guid { get; set; }
        public string expire { get; set; }
        public string user { get; set; }
        public string status { get; set; }
    }
}
