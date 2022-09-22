using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Users = new HashSet<User>();
            Workings = new HashSet<Working>();
        }

        public int Id { get; set; }
        public string? Comment1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Working> Workings { get; set; }
    }
}
