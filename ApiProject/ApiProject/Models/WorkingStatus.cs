using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class WorkingStatus
    {
        public WorkingStatus()
        {
            Workings = new HashSet<Working>();
        }

        public int WorkingStatusId { get; set; }
        public string? WorkingStatusName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Working> Workings { get; set; }
    }
}
