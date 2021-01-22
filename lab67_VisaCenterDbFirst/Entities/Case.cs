using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
        public int ServiceId { get; set; }
        public int ConsulId { get; set; }
        public int StatusId { get; set; }
        public DateTime CaseStartDate { get; set; }
        public DateTime? CaseFinishDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Consul Consul { get; set; }
        public virtual VisaManager Manager { get; set; }
        public virtual Service Service { get; set; }
        public virtual Status Status { get; set; }
    }
}
