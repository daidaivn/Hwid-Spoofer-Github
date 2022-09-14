using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingController : ControllerBase
    {
        private readonly IWorkingService _workingService;
        public WorkingController(IWorkingService workingservice)
        {
            _workingService = workingservice;
        }
        [Route("get-all-working")]
        [HttpGet]
        public dynamic GetAll()
        {
            try
            {
                var data = _workingService.GetAllWoking();
                return data;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create-working")]
        [HttpPost]
        public dynamic CreateWoking(Working working)
        {
            try
            {
                var data = _workingService.CreateWoking(working);
                return Ok(working);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
                
        }

    }
}
