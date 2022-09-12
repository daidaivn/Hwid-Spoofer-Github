using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class User
    {
        public User()
        {
            WorkAndUsers = new HashSet<WorkAndUser>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Passwork { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public bool? Gender { get; set; }
        public int RoleId { get; set; }
        public bool? Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<WorkAndUser> WorkAndUsers { get; set; }
    }
}
