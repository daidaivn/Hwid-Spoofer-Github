using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Prioritized
    {
        public Prioritized()
        {
            Workings = new HashSet<Working>();
        }

        public int PrioritizedId { get; set; }
        public string? PrioritizedName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Working> Workings { get; set; }
    }
}
