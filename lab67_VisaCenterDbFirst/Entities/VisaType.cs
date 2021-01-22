using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class VisaType
    {
        public VisaType()
        {
            Services = new HashSet<Service>();
        }

        public int VisaTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
