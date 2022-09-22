using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UWController : ControllerBase
    {
        private readonly IUWService _uwservice;
        public UWController(IUWService uwservice)
        {
            _uwservice = uwservice;
        }
        [Route("getall")]
        [HttpGet]
        public dynamic GetAllUW()
        {
            try
            {
                var data = _uwservice.GetAllUW();
                return data;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic UpdateUW(Working working)
        {
            try
            {
                var data = _uwservice.UpdateUW(working);
                return data;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("creat")]
        [HttpPost]
        public dynamic CreateUW(Working working)
        {
            try
            {
                var data = _uwservice.CreateUW(working);
                return data;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
