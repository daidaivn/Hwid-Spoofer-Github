using ApiProject.IServices;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [Route("paging")]
        [HttpGet]
        public dynamic GetCurrentPage(int page)
        {
            try
            {
                var data = _commentService.GetCurrentPage(page);
                return data;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        [Route("get-all")]
        [HttpGet]
        public dynamic getAllComment()
        {
            try
            {
                var data = _commentService.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create")]
        [HttpPost]
        public dynamic Create(Comment comment)
        {
            try
            {
                var data = _commentService.CreateComment(comment);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic UpdateComment(Comment comment)
        {
            try
            {
                var data = _commentService.UpdateComment(comment);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("delete")]
        [HttpDelete]
        public dynamic DeleteComment(Comment comment)
        {
            try
            {
                var data = _commentService.DeleteComment(comment);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-id")]
        [HttpPost]
        public dynamic SearchById(Comment comment,int page)
        {
            try
            {
                var data = _commentService.SearchById(comment,page);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Search-by-name")]
        [HttpPost]
        public dynamic SearchByName(Comment comment, int page)
        {
            try
            {
                var data = _commentService.SearchByName(comment,page);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
