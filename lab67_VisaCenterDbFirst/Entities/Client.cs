using System;
using System.Collections.Generic;

#nullable disable

namespace lab67_VisaCenterAPI.Entities
{
    public partial class Client
    {
        public Client()
        {
            Cases = new HashSet<Case>();
            Reviews = new HashSet<Review>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
