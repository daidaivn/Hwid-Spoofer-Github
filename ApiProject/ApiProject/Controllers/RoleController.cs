using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;
        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [Route("all")]
        [HttpGet]
        public dynamic getAllRole()
        {
            try
            {
                var data = _roleServices.getAllRole();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
