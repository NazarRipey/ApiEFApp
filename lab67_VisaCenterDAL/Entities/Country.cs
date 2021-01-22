using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab67_VisaCenterDAL.Entities
{
    public class Country
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Consul> Consuls { get; set; }
    }
}
