using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface ICategoryService
    {
        public dynamic pagingCate(int page);
        public IQueryable<dynamic> getAllCategory();
        public dynamic UpdateCategory(Category category);
        public dynamic SearchByCategoryName(Category category,int page);
        public dynamic SearchByCategoryId(Category category,int page);
        public dynamic CreateCategory(Category category);
        public dynamic ChangeStatus(Category category);

    }
}
