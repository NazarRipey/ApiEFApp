using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab67_VisaCenterDAL.Entities
{
    public class Consul
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
