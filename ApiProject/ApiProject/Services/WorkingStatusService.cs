
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
            return _context.WorkingStatuses.Select(c => new
            {
                c.WorkingStatusId,
                c.WorkingStatusName,
                c.Status,
                Workings = from r in c.Workings
                           select new
                           {
                               r.WorkingId, 
                           }
            });
        }
        public dynamic CreateWorkingStatus(WorkingStatus workingStatus)
        {
            if (workingStatus.WorkingStatusName.Trim().Equals(""))
            {
                return false;
            }
            WorkingStatus ws = new WorkingStatus
            {
                WorkingStatusName = workingStatus.WorkingStatusName.Trim(),
                Status = true,
            };
            _context.WorkingStatuses.Add(ws);
            _context.SaveChanges();
            return ws;
        }
        public dynamic UpdateWorkingStatus(WorkingStatus workingStatus)
        {
            var checkId = _context.WorkingStatuses.FirstOrDefault(c => c.WorkingStatusId == workingStatus.WorkingStatusId);
            if (checkId == null || workingStatus.WorkingStatusName.Trim().Equals(""))
            {
                return false;
            }
            else
            {
                checkId.WorkingStatusName = workingStatus.WorkingStatusName.Trim();
                _context.WorkingStatuses.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }

        public dynamic ChangeStatus(WorkingStatus workingStatus)
        {
            var checkId = _context.WorkingStatuses.FirstOrDefault(c => c.WorkingStatusId == workingStatus.WorkingStatusId);
            if (checkId == null)
            {
                return false;
            }
            else
            {
                checkId.Status = !checkId.Status;
                _context.WorkingStatuses.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }

        public IQueryable<dynamic> SearchByWorkingStatusName(WorkingStatus workingStatus)
        {
            var keyword = _context.WorkingStatuses.Where(c => c.WorkingStatusName.Contains(workingStatus.WorkingStatusName.Trim()));
            if (keyword == null)
            {
                return null;
            }
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchByWorkingStatusId(WorkingStatus workingStatus)
        {
            var keyword = _context.WorkingStatuses.FirstOrDefault(c => c.WorkingStatusId == workingStatus.WorkingStatusId);
            if (keyword == null)
            {
                return false;
            }
            return keyword;
        }
    }

}