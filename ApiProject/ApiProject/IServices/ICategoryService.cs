using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface ICategoryService
    {
<<<<<<< HEAD
        public dynamic pagingCate(int page);
=======

        public dynamic pagingCate(int page);

       // public dynamic GetCurrentPage(int page);
>>>>>>> f459203318349b72f96f3d55b236f0acc49e0efd
        public IQueryable<dynamic> getAllCategory();
        public dynamic UpdateCategory(Category category);
        public dynamic SearchByCategoryName(Category category,int page);
        public dynamic SearchByCategoryId(Category category,int page);
        public dynamic CreateCategory(Category category);
        public dynamic ChangeStatus(Category category);

    }
}
