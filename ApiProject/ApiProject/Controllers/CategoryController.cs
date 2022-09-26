using ApiProject.IServices;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("paging")]
        [HttpGet]
        public dynamic pagingCate(int page)
        {
<<<<<<< HEAD
=======

>>>>>>> f459203318349b72f96f3d55b236f0acc49e0efd
            try
            {
                var data = _categoryService.pagingCate(page);
                return data;
            }catch(Exception e)
            {
                return e.Message;
            }
            
<<<<<<< HEAD
=======

>>>>>>> f459203318349b72f96f3d55b236f0acc49e0efd
        }

        [Route("get-all")]
        [HttpGet]
        public dynamic getAllCategory()
        {
            try
            {
                var data = _categoryService.getAllCategory();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create")]
        [HttpPost]
        public dynamic Create(Category category)
        {
            try
            {
                var data = _categoryService.CreateCategory(category);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic UpdateCategory(Category category)
        {
            try
            {
                var data = _categoryService.UpdateCategory(category);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("change-status")]
        [HttpPost]
        public dynamic ChangeStatus(Category category)
        {
            try
            {
                var data = _categoryService.ChangeStatus(category);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-name")]
        [HttpPost]
        public dynamic SearchByCategoryName(Category category, int page)
        {
            try
            {
                var data = _categoryService.SearchByCategoryName(category,page);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-id")]
        [HttpPost]
        public dynamic SearchByCategoryId(Category category,int page)
        {
            try
            {
                var data = _categoryService.SearchByCategoryId(category,page);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
