using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class WorkingService : IWorkingServices
    {
        private readonly TestTek4TvContext _context;
        public WorkingService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> getAllWorking()
        {
            var items = _context.Workings.Include(w1=>w1.Categories).Include(w2=>w2.Users);
            var output = from item in items
                         select new
                         {
                             item.WorkingId,
                             item.WorkingName,
                             item.DateCreate,
                             item.Deadline,
                             item.WorkingStatus,
                             item.Prioritized,
                             item.Categories,
                             item.UserConfirm,
                             item.Description,
                         };
            return output;
        }
        public dynamic CreateWorking(Working working)
        {
            if (working.WorkingName.Trim().Equals(""))
            {
                return false;
            }
            var nwork = new Working
            {
                //WorkingId = working.WorkingId,
                WorkingName = working.WorkingName,
                DateCreate = working.DateCreate,
                Deadline = working.Deadline,
                WorkingStatusId = working.WorkingStatusId,
                PrioritizedId = working.PrioritizedId,
                UserConfirm = working.UserConfirm,
                Description = working.Description,   
            };
            _context.Workings.Add(nwork);
            _context.SaveChanges();
            return nwork;
        }
        public dynamic UpdateWorking(Working working)
        {
            var checkId = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            if (checkId == null || working.WorkingName.Trim().Equals(""))
            {
                return false;
            }
            checkId.WorkingName = working.WorkingName;
            checkId.DateCreate = working.DateCreate;
            checkId.Deadline = working.Deadline;
            checkId.WorkingStatusId = working.WorkingStatusId;
            checkId.PrioritizedId = working.PrioritizedId;
            checkId.UserConfirm = working.UserConfirm;
            checkId.Description = working.Description;
            _context.Workings.Update(checkId);
            _context.SaveChanges();
            return checkId;

        }
        public IQueryable<dynamic> SearchByWorkingName(Working working)
        {
            var keyword = _context.Workings.Where(c => c.WorkingName.Contains(working.WorkingName.Trim()));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchWorkingById(Working working)
        {
            var pzById = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            return pzById;
        }
    }
}
