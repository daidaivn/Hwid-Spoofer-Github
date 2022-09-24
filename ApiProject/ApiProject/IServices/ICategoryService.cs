using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface ICategoryService
    {
<<<<<<< HEAD
        public dynamic pagingCate(int page);
=======
        public dynamic GetCurrentPage(int page);
>>>>>>> a9658ab5f533a641d1018b7843d4a6845a6f83b8
        public IQueryable<dynamic> getAllCategory();
        public dynamic UpdateCategory(Category category);
        public dynamic SearchByCategoryName(Category category,int page);
        public dynamic SearchByCategoryId(Category category,int page);
        public dynamic CreateCategory(Category category);
        public dynamic ChangeStatus(Category category);

    }
}
