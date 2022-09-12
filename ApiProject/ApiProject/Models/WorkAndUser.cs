using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class WorkAndUser
    {
        public int WorkingId { get; set; }
        public string? WorkingName { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? Deadline { get; set; }
        public int UserId { get; set; }
        public int WorkingStatusId { get; set; }
        public int PrioritizedId { get; set; }
        public int? UserConfirm { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }

        public virtual Prioritized Prioritized { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual Working Working { get; set; } = null!;
        public virtual WorkingStatus WorkingStatus { get; set; } = null!;
    }
}
