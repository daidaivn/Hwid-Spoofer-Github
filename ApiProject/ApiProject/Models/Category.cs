using System;
using System.Collections.Generic;

namespace ApiProject.Models
{
    public partial class Category
    {
        public Category()
        {
            Workings = new HashSet<Working>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Working> Workings { get; set; }
    }
}
