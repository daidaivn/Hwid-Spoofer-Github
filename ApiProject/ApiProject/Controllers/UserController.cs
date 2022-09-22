using ApiProject.IServices;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [Route("all-user")]
        [HttpGet]
        public dynamic getAllUser()
        {
            try
            {
                var data = _userServices.getAllUser();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create-user")]
        [HttpPost]
        public dynamic Create(User user)
        {
            try
            {
                var keyCreated = _userServices.CreateUser(user);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [Route("create-user-role")]
        [HttpPost]
        public dynamic CreateUserRole(User user)
        {
            try
            {
                var keyCreated = _userServices.CreateUserRole(user);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update-user-role")]
        [HttpPost]
        public dynamic UpdateUserRole(User user)
        {
            try
            {
                var keyCreated = _userServices.UpdateUserRole(user);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [Route("update-user")]
        [HttpPut]
        public dynamic UpdateUser(User user)
        {
            try
            {
                var keyUpdate = _userServices.UpdateUser(user);
                return Ok(keyUpdate);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-user-name")]
        [HttpPost]
        public dynamic SearchByUserName(User user)
        {
            try
            {
                var data1 = _userServices.SearchByName(user);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-user-id")]
        [HttpPost]
        public dynamic SearchByUserID(User user)
        {
            try
            {
                var data1 = _userServices.SearchUserById(user);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [Route("change-status")]
        [HttpPost]
        public dynamic ChangeStatus(User user)
        {
            try
            {
                var data1 = _userServices.ChangeStatus(user);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
