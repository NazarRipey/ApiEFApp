using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab67_VisaCenterDAL.Entities
{
    public class Manager
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0, 60)]
        public int Experience { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
