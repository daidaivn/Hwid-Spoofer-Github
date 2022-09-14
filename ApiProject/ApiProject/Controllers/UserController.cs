using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProject.IServices;
using ApiProject.Models;

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
        [Route("get-all-users")]
        [HttpGet]
        public dynamic GetALlUser()
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
        public dynamic CreatUser(User user)
        {
            try
            {
                var data = _userServices.CreateUser(user);
                return Ok(data);
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
                var data = _userServices.UpdateUser(user);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("change-status-user")]
        [HttpDelete]
        public dynamic ChangeStatus(User user)
        {
            try
            {
                var data = _userServices.ChangeStatus(user);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        [Route("search-by-user-name")]
        [HttpPost]
        public dynamic SearchByUserName(User user)
        {
            try
            {
                var data = _userServices.SearchByUserName(user);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-user-id")]
        [HttpPost]
        public dynamic SearchByUserId(User user)
        {
            try
            {
                var data = _userServices.SearchByUserId(user);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
