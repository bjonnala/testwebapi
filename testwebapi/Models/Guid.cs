using System;
using System.Collections.Generic;

namespace testwebapi.Models
{
    public partial class Guid
    {
        public int GuidId { get; set; }
        public string UniqueId { get; set; }
        public string Expires { get; set; }
        public string User { get; set; }
    }
}
