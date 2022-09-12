using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Prioritized
    {
        public Prioritized()
        {
            WorkAndUsers = new HashSet<WorkAndUser>();
        }

        public int PrioritizedId { get; set; }
        public string? PrioritizedName { get; set; }

        public virtual ICollection<WorkAndUser> WorkAndUsers { get; set; }
    }
}
