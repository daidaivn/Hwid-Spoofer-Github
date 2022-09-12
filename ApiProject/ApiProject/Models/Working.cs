using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Working
    {
        public int WorkingId { get; set; }
        public string? WorkingName { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? Deadline { get; set; }
        public bool? Status { get; set; }

        public virtual WorkAndUser WorkAndUser { get; set; } = null!;
    }
}
