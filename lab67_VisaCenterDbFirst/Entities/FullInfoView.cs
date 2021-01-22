using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class FullInfoView
    {
        public string ClientName { get; set; }
        public string ManagerName { get; set; }
        public string ConsulName { get; set; }
        public string CountryName { get; set; }
        public string VisaTypeName { get; set; }
        public string Status { get; set; }
        public DateTime CaseStartDate { get; set; }
        public DateTime? CaseFinishDate { get; set; }
    }
}
