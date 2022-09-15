
using ApiProject.Models;
using ApiProject.IServices;

namespace ApiProject.Services
{
    public class WorkingStatusService : IWorkingStatusService
    {
        private readonly TestTek4TvContext _context;
        public WorkingStatusService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> getAllWorkingStats()
        {
            return _context.WorkingStatuses;
        }
        public dynamic CreateWorkingStatus(WorkingStatus workingStatus)
        {
            WorkingStatus ws = new WorkingStatus
            {
                WorkingStatusName = workingStatus.WorkingStatusName
            };
            _context.WorkingStatuses.Add(ws);
            _context.SaveChanges();
            return ws;
        }
        public dynamic UpdateWorkingStatus(WorkingStatus workingStatus)
        {
            var checkId = _context.WorkingStatuses.FirstOrDefault(c => c.WorkingStatusId == workingStatus.WorkingStatusId);
            if (checkId == null)
            {
                return false;
            }
            else
            {
                checkId.WorkingStatusId = workingStatus.WorkingStatusId;
                checkId.WorkingStatusName = workingStatus.WorkingStatusName;
                _context.WorkingStatuses.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }
        public IQueryable<dynamic> SearchByWorkingStatusName(WorkingStatus workingStatus)
        {
            var keyword = _context.WorkingStatuses.Where(c => c.WorkingStatusName.Contains(workingStatus.WorkingStatusName));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchByWorkingStatusId(WorkingStatus workingStatus)
        {
            var keyword = _context.WorkingStatuses.FirstOrDefault(c => c.WorkingStatusId == workingStatus.WorkingStatusId);
            return keyword;
        }
    }

}