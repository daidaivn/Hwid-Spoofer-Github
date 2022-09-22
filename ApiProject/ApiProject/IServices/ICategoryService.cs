using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface ICategoryService
    {
        public IQueryable<dynamic> getAllCategory();
        public dynamic UpdateCategory(Category category);
        public IQueryable<dynamic> SearchByCategoryName(Category category);
        public dynamic SearchByCategoryId(Category category);
        public dynamic CreateCategory(Category category);
        public dynamic ChangeStatus(Category category);

    }
}
