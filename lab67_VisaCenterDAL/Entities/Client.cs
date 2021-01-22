using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab67_VisaCenterDAL.Entities
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
