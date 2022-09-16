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

        [Route("all-working")]
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
        [Route("create-working")]
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
        [Route("update-working")]
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
        [Route("search-working-name")]
        [HttpPost]
        public dynamic SearchByWorkingName(Working working)
        {
            try
            {
                var data1 = _workingServices.SearchByWorkingName(working);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-working-id")]
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
