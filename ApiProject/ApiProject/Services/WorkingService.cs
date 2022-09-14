using ApiProject.IServices;
using ApiProject.Models;

namespace ApiProject.Services
{
    public class WorkingService : IWorkingService  
    {
        private readonly TestTek4TvContext _context;
        public WorkingService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> GetAllWoking()
        {
            return _context.Workings;
        }
        public dynamic CreateWoking(Working working)
        {
            Working NewWorking = new Working
            {
                WorkingName = working.WorkingName,
                DateCreate = working.DateCreate,
                Deadline = working.Deadline,
                Status = working.Status,
            };
            _context.Workings.Add(NewWorking);
            _context.SaveChanges();
            return NewWorking;
        }
        public dynamic UpdateWorking(Working working)
        {
            var checkId = _context.Workings.FirstOrDefault(c => c.WorkingId== working.WorkingId);
            if (checkId == null)
            {
                return false;
            }
            else
            {
                checkId.WorkingId = working.WorkingId;
                checkId.WorkingName = working.WorkingName;
                checkId.DateCreate = working.DateCreate;
                checkId.Deadline = working.Deadline;
                checkId.Status = working.Status;
                _context.Workings.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }
        public dynamic ChangeStatus(Working working)
        {
            var a = working.Status;
            var checkId = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            if (checkId != null)
            {
                checkId.Status = a;
                _context.Update(checkId);
                return checkId;
            }
            else
            {
                return false;
            }
        }
        public IQueryable<dynamic> SearchByWorkingName(Working working)
        {
            var keyword = _context.Workings.Where(c => working.WorkingName.Contains(working.WorkingName));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchByWorkingId(Working working)
        {
            var keyword = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            return keyword;
        }

    }
}
