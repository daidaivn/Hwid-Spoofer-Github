using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingController : ControllerBase
    {
        private readonly IWorkingServices _workingServices;
        public WorkingController(IWorkingServices workingServices)
        {
            _workingServices = workingServices;
        }

        [Route("get-all")]
        [HttpGet]
        public dynamic getAllWorking()
        {
            try
            {
                var data = _workingServices.getAllWorking();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("paging")]
        [HttpGet]
        public dynamic pagingWorking(int page)
        {
            try
            {
                var data = _workingServices.pagingWorking(page);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create")]
        [HttpPost]
        public dynamic Create(Working working)
        {
            try
            {
                var keyCreated = _workingServices.CreateWorking(working);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic UpdateWorking(Working working)
        {
            try
            {
                var keyUpdate = _workingServices.UpdateWorking(working);
                return Ok(keyUpdate);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create-connect")]
        [HttpPost]
        public dynamic CreateConnect(Working working)
        {
            try
            {
                var keyCreated = _workingServices.CreateConnect(working);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update-connect")]
        [HttpPut]
        public dynamic UpdateConnect(Working working)
        {
            try
            {
                var keyUpdate = _workingServices.UpdateConnect(working);
                return Ok(keyUpdate);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-name")]
        [HttpPost]
        public dynamic SearchByWorkingName(Working working, int page)
        {
            try
            {
                var data1 = _workingServices.SearchByWorkingName(working,page);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-id")]
        [HttpPost]
        public dynamic SearchByWorkingID(Working working)
        {
            try
            {
                var data1 = _workingServices.SearchWorkingById(working);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
