using ApiProject.IServices;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritizedController : ControllerBase
    {
        private readonly IPrioritizedServices _prioritizedServices;
        public PrioritizedController(IPrioritizedServices prioritizedServices)
        {
            _prioritizedServices = prioritizedServices;
        }
        [Route("paging")]
        [HttpGet]
        public dynamic GetCurrentPage(int page)
        {
            try
            {
                var data = _prioritizedServices.GetCurrentPage(page);
                return data;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        [Route("get-all")]
        [HttpGet]
        public dynamic getAllPrioritized()
        {
            try
            {
                var data = _prioritizedServices.getAllPz();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create")]
        [HttpPost]
        public dynamic CreatePz(Prioritized prioritized)
        {
            try
            {
                var data = _prioritizedServices.CreatePz(prioritized);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic Update(Prioritized prioritized)
        {
            try
            {
                var data = _prioritizedServices.UpdatePz(prioritized);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("change-status")]
        [HttpPost]
        public dynamic ChangeStatus(Prioritized prioritized)
        {
            try
            {
                var data = _prioritizedServices.ChangeStatus(prioritized);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-name")]
        [HttpPost]
        public dynamic SearchByRoleName(Prioritized prioritized)
        {
            try
            {
                var data = _prioritizedServices.SearchByPzName(prioritized);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-id")]
        [HttpPost]
        public dynamic SearchByRoleID(Prioritized prioritized)
        {
            try
            {
                var data = _prioritizedServices.SearchPzById(prioritized);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
