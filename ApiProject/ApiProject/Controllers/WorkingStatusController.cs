using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingStatusController : ControllerBase
    {
        private readonly IWorkingStatusService _workingStatusService;
        public WorkingStatusController(IWorkingStatusService workingStatusService)
        {
            _workingStatusService = workingStatusService;
        }

        [Route("get-all-working-status")]
        [HttpGet]
        public dynamic getAllWorkingStatus()
        {
            try
            {
                var data = _workingStatusService.getAllWorkingStats();
                return Ok(data);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("creat-working-status")]
        [HttpPost]
        public dynamic Create(WorkingStatus workingStatus)
        {
            try
            {
                var Created = _workingStatusService.CreateWorkingStatus(workingStatus);
                return Ok(Created);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("update-working-status")]
        [HttpPut]
        public dynamic UpdateWorkingStatus(WorkingStatus workingStatus)
        {
            try
            {
                var Updated = _workingStatusService.UpdateWorkingStatus(workingStatus);
                return Ok(Updated);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-working-status-name")]
        [HttpPost]
        public dynamic SearchByWorkingStatusName(WorkingStatus workingStatus)
        {
            try
            {
                var result1 = _workingStatusService.SearchByWorkingStatusName(workingStatus);
                return Ok(result1);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        [Route("search-working-status-id")]
        [HttpPost]
        public dynamic SearchByWorkingStatusId(WorkingStatus workingStatus)
        {
            try
            {
                var result2 = _workingStatusService.SearchByWorkingStatusId(workingStatus);
                return Ok(result2);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}