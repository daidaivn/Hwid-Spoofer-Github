using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Workings = new HashSet<Working>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public int GenderId { get; set; }
        public bool? Status { get; set; }

        public virtual Gender Gender { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Working> Workings { get; set; }
    }
}
