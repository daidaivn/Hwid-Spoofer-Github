
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
        public dynamic pagingCate(int page)
        {
            var pageRes = 2f;
            var pageCount = Math.Ceiling(_context.Categories.Count()/pageRes);

            var categories = _context.Categories.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            return categories;
        }
        public IQueryable<dynamic> getAllCategory()
        {
            var items = _context.Categories;
            var output = from item in items
                         select new
                         {
                             item.CategoryId,
                             item.CategoryName,
                             item.Status,
                         };
            return output;
        }
        public dynamic CreateCategory(Category category)
        {
            if (category.CategoryName.Trim().Equals(""))
            {
                return false;
            }
            Category newcategory = new Category
            {
                CategoryName = category.CategoryName.Trim(),
                Status = true,
            };
            _context.Categories.Add(newcategory);
            _context.SaveChanges();
            return newcategory;
        }
        public dynamic UpdateCategory(Category category)
        {
            var checkId = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (checkId == null ||category.CategoryName.Trim().Equals(""))
            {
                return false;
            }
            else
            {
                checkId.CategoryId = category.CategoryId;
                checkId.CategoryName = category.CategoryName.Trim();
                checkId.Status = category.Status;
                _context.Categories.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }
        // Change Status
        public dynamic ChangeStatus(Category category)
        {
            var checkId = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (checkId == null)
            {
                return false;
            }
            else
            {
              
                checkId.Status =! checkId.Status;
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