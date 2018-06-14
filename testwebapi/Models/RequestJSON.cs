using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testwebapi.Models
{
    public class RequestJSON
    {
       
        public string expire { get; set; }
        [Required]
        public string user { get; set; }
        public string guid { get; set; }
    }
}
