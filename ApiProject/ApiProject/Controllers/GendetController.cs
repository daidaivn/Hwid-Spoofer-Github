using ApiProject.IServices;
using ApiProject.Models;
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

        [Route("all-gender")]
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
        [Route("create-gender")]
        [HttpPost]
        public dynamic Create(Gender gender)
        {
            try
            {
                var keyCreated = _genderServices.CreateGender(gender);
                return Ok(keyCreated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update-gender")]
        [HttpPut]
        public dynamic UpdateGender(Gender gender)
        {
            try
            {
                var keyUpdate = _genderServices.UpdateGender(gender);
                return Ok(keyUpdate);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-gender-name")]
        [HttpPost]
        public dynamic SearchByGenderName(Gender gender)
        {
            try
            {
                var data1 = _genderServices.SearchByGenderName(gender);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-gender-id")]
        [HttpPost]
        public dynamic SearchByGenderID(Gender gender)
        {
            try
            {
                var data1 = _genderServices.SearchGenderById(gender);
                return Ok(data1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
