using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class WorkingStatus
    {
        public WorkingStatus()
        {
            WorkAndUsers = new HashSet<WorkAndUser>();
        }

        public int WorkingStatusId { get; set; }
        public string? WorkingStatusName { get; set; }

        public virtual ICollection<WorkAndUser> WorkAndUsers { get; set; }
    }
}
