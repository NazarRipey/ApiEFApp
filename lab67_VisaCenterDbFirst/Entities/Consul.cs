using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Consul
    {
        public Consul()
        {
            Cases = new HashSet<Case>();
            Secretaries = new HashSet<Secretary>();
        }

        public int ConsulId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int? Experience { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Secretary> Secretaries { get; set; }
    }
}
