using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class FiredManager
    {
        public int? ManagerId { get; set; }
        public string Name { get; set; }
        public DateTime? FireDate { get; set; }
    }
}
