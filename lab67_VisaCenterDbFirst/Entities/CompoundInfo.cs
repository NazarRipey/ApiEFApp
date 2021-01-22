using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class CompoundInfo
    {
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string VisaManagerName { get; set; }
        public int? VisaManagerExperience { get; set; }
        public string CountryName { get; set; }
        public string CounsulName { get; set; }
        public string StatusName { get; set; }
        public DateTime? CaseStartDate { get; set; }
        public string VisaTypeName { get; set; }
    }
}
