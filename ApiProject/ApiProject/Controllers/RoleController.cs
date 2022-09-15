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

        [Route("all-role")]
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
        [Route("create-role")]
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
        [Route("update-role")]
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
        [Route("search-role-name")]
        [HttpPost]
        public dynamic SearchByRoleName(Role role)
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
        [Route("search-role-id")]
        [HttpPost]
        public dynamic SearchByRoleID(Role role)
        {
            try
            {
                var data1 = _roleServices.SearchRoleById(role);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
