using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Secretary
    {
        public int SecretaryId { get; set; }
        public int ConsulId { get; set; }
        public string Name { get; set; }

        public virtual Consul Consul { get; set; }
    }
}
