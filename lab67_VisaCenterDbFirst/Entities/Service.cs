using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Service
    {
        public Service()
        {
            Cases = new HashSet<Case>();
        }

        public int ServiceId { get; set; }
        public int VisaTypeId { get; set; }
        public int CountryId { get; set; }
        public decimal? Price { get; set; }

        public virtual Country Country { get; set; }
        public virtual VisaType VisaType { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
    }
}
