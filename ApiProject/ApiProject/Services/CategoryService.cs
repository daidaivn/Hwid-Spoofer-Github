
using ApiProject.Models;
using ApiProject.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly TestTek4TvContext _context;
        public CategoryService(TestTek4TvContext context)
        {
            _context = context;
        }
<<<<<<< HEAD
        public dynamic pagingCate(int page)
        {
            var pageRes = 2f;
            var categories = _context.Categories.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            return categories;
=======

        public dynamic pagingCate(int page)

       // public dynamic GetCurrentPage (int page)

        {
            var pageRes = 2f;
            var categories = _context.Categories.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();

            //return categories;

>>>>>>> f459203318349b72f96f3d55b236f0acc49e0efd
            var pageCount = Math.Ceiling(_context.Categories.Count()/pageRes);
            var output = categories.Select(c => new
            {
                c.CategoryId,
                c.CategoryName,
                c.Status,
                pageCount,
            });
            return output;
<<<<<<< HEAD
=======

>>>>>>> f459203318349b72f96f3d55b236f0acc49e0efd
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

        public dynamic SearchByCategoryName(Category category,int page)
        {
            var checkId = _context.Categories.Where(c => c.CategoryName.Contains(category.CategoryName.Trim()));
            var pageRes = 2f;
            var categories = checkId.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var pageCount = Math.Ceiling(checkId.Count() / pageRes);
            var output = categories.Select(c => new
            {
                c.CategoryId,
                c.CategoryName,
                c.Status,
                pageCount,
            });
            return output;
            //return keyword.ToList().AsQueryable();
        }
        public dynamic SearchByCategoryId (Category category,int page)
        {
            var checkId = _context.Categories.Include(c=>c.Workings).FirstOrDefault(c => c.CategoryId == category.CategoryId);
            return checkId;
        }
    }

}