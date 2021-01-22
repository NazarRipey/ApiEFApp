using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int ClientId { get; set; }
        public int? ManagerId { get; set; }
        public int Grade { get; set; }
        public string Review1 { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual Client Client { get; set; }
    }
}
