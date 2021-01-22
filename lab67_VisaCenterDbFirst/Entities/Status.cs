using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Status
    {
        public Status()
        {
            Cases = new HashSet<Case>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
