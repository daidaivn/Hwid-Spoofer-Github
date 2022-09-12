using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Route("getAllRole")]
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
        [Route("create")]
        [HttpPost]
        public dynamic Create(Role role)
        {
            try
            {
                var keyCreated = _roleServices.CreateRole(role);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("Update")]
        [HttpPut]
        public dynamic UpdateRole(Role role)
        {
            try
            {
                var keyUpdate = _roleServices.UpdateRole(role);
                return Ok(keyUpdate);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("SearchByRoleName")]
        [HttpPost]
        public dynamic SearchByRole(Role role)
        {
            try
            {
                var data1 = _roleServices.SearchByRoleName(role);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
