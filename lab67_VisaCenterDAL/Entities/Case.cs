using System;
using System.ComponentModel.DataAnnotations;

namespace lab67_VisaCenterDAL.Entities
{
    public class Case
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ConsulId { get; set; }

        [Required]
        public int ManagerId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Consul Consul { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual Status Status { get; set; }
    }
}
