namespace ApiProject.Models
{
    public class CategoryRes
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
