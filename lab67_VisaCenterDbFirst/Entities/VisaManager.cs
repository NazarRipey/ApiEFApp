using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class VisaManager
    {
        public VisaManager()
        {
            Cases = new HashSet<Case>();
        }

        public int ManagerId { get; set; }
        public string Name { get; set; }
        public decimal? Rating { get; set; }
        public int Experience { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
