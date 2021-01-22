using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Country
    {
        public Country()
        {
            Consuls = new HashSet<Consul>();
            Services = new HashSet<Service>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? PriceCoef { get; set; }

        public virtual ICollection<Consul> Consuls { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
