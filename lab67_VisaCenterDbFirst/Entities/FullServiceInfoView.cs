using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class FullServiceInfoView
    {
        public string Country { get; set; }
        public string VisaType { get; set; }
        public decimal? Price { get; set; }
    }
}
