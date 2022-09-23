using ApiProject.IServices;
using ApiProject.Models;
using ApiProject.Services;
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

        [Route("get-all")]
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

        [Route("paging")]
        [HttpPost]
        public dynamic getAllRole(int page)
        {
            try
            {
                var data = _roleServices.pagingRole(page);
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
        [Route("update")]
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
        [Route("change-status")]
        [HttpPost]
        public dynamic ChangeStatus(Role role)
        {
            try
            {
                var result2 = _roleServices.ChangeStatus(role);
                return Ok(result2);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-name")]
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
        [Route("search-by-id")]
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
