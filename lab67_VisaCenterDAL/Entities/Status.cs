using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab67_VisaCenterDAL.Entities
{
    public class Status
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
