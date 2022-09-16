
using ApiProject.Models;
using ApiProject.IServices;

namespace ApiProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly TestTek4TvContext _context;
        public CategoryService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> getAllCategory()
        {
            return _context.Categories;
        }
        public dynamic CreateCategory(Category category)
        {
            Category newcategory = new Category
            {
                CategoryName = category.CategoryName,
                Status = true,
            };
            _context.Categories.Add(newcategory);
            _context.SaveChanges();
            return newcategory;
        }
        public dynamic UpdateCategory(Category category)
        {
            var checkId = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (checkId == null)
            {
                return false;
            }
            else
            {
                checkId.CategoryId = category.CategoryId;
                checkId.CategoryName = category.CategoryName;
                //checkId.Status = category.Status;
                _context.Categories.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }
        // Change Status
        public dynamic DeleteCategory(Category category)
        {
            var checkId = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (checkId == null)
            {
                return false;
            }
            else
            {
              
                checkId.Status = false;
                _context.Categories.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }

        public IQueryable<dynamic> SearchByCategoryName(Category category)
        {
            var keyword = _context.Categories.Where(c => c.CategoryName.Contains(category.CategoryName));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchByCategoryId(Category category)
        {
            var keyword = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            return keyword;
        }
    }

}