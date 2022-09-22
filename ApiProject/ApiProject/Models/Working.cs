using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Working
    {
        public Working()
        {
            Categories = new HashSet<Category>();
            Users = new HashSet<User>();
        }

        public int WorkingId { get; set; }
        public string? WorkingName { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? Deadline { get; set; }
        public int? WorkingStatusId { get; set; }
        public int? PrioritizedId { get; set; }
        public string? UserConfirm { get; set; }
        public string? Description { get; set; }

        public virtual Prioritized? Prioritized { get; set; }
        public virtual WorkingStatus? WorkingStatus { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
