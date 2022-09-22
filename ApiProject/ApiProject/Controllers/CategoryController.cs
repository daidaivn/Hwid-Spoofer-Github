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
                var Created = _categoryService.CreateCategory(category);
                return Ok(Created);
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
                var Updated = _categoryService.UpdateCategory(category);
                return Ok(Updated);
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
                var result2 = _categoryService.ChangeStatus(category);
                return Ok(result2);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-name")]
        [HttpPost]
        public dynamic SearchByCategoryName(Category category)
        {
            try
            {
                var result1 = _categoryService.SearchByCategoryName(category);
                return Ok(result1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-id")]
        [HttpPost]
        public dynamic SearchByCategoryId(Category category)
        {
            try
            {
                var result2 = _categoryService.SearchByCategoryId(category);
                return Ok(result2);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
