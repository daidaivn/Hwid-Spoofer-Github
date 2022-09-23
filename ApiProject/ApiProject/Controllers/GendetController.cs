using ApiProject.IServices;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderServices _genderServices;
        public GenderController(IGenderServices genderServices)
        {
            _genderServices = genderServices;
        }
        [Route("paging")]
        [HttpGet]
        public dynamic GetCurrentPage(int page)
        {
            try
            {
                var data = _genderServices.GetCurrentPage(page);
                return data;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        [Route("get-all")]
        [HttpGet]
        public dynamic getAllGender()
        {
            try
            {
                var data = _genderServices.getAllGender();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("create")]
        [HttpPost]
        public dynamic Create(Gender gender)
        {
            try
            {
                var data = _genderServices.CreateGender(gender);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update")]
        [HttpPut]
        public dynamic UpdateGender(Gender gender)
        {
            try
            {
                var data = _genderServices.UpdateGender(gender);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("change-status")]
        [HttpPost]
        public dynamic ChangeStatus(Gender gender)
        {
            try
            {
                var data = _genderServices.ChangeStatus(gender);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-name")]
        [HttpPost]
        public dynamic SearchByGenderName(Gender gender)
        {
            try
            {
                var data = _genderServices.SearchByGenderName(gender);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-by-id")]
        [HttpPost]
        public dynamic SearchByGenderID(Gender gender)
        {
            try
            {
                var data = _genderServices.SearchGenderById(gender);
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
