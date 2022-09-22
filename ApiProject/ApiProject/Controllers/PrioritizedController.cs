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
                var keyCreated = _prioritizedServices.CreatePz(prioritized);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic UpdateRole(Prioritized prioritized)
        {
            try
            {
                var keyUpdate = _prioritizedServices.UpdatePz(prioritized);
                return Ok(keyUpdate);
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
                var result2 = _prioritizedServices.ChangeStatus(prioritized);
                return Ok(result2);
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
                var data1 = _prioritizedServices.SearchByPzName(prioritized);
                return Ok(data1);
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
                var data1 = _prioritizedServices.SearchPzById(prioritized);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
