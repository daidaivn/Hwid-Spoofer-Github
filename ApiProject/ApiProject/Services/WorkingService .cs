using ApiProject.IServices;
using ApiProject.Models;

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
            var items = _context.Workings;
            var output = from item in items
                         select new
                         {
                             item.WorkingId,
                             item.WorkingName,
                             item.DateCreate,
                             item.Deadline,
                             item.Prioritized,
                             item.Categories,
                             item.UserConfirm,
                             item.Description,
                         };
            return output;
        }
        public dynamic CreateWorking(Working working)
        {

            Working nwork = new Working
            {
                WorkingName = working.WorkingName,
                DateCreate = working.DateCreate,
                Deadline = working.Deadline,
                Prioritized = working.Prioritized,
                Categories = working.Categories,
                UserConfirm = working.UserConfirm,
                Description = working.Description,
                WorkingStatusId = working.WorkingStatusId,
            };
            _context.Workings.Add(nwork);
            _context.SaveChanges();
            return nwork;
        }
        public dynamic UpdateWorking(Working working)
        {
            var checkId = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            if (checkId == null)
            {
                return false;
            }
            checkId.WorkingName = working.WorkingName;
            checkId.DateCreate = working.DateCreate;
            checkId.Deadline = working.Deadline;
            checkId.Prioritized = working.Prioritized;
            checkId.Categories = working.Categories;
            checkId.UserConfirm = working.UserConfirm;
            checkId.Description = working.Description;
            checkId.WorkingStatusId = working.WorkingStatusId;

            _context.Workings.Update(checkId);
            _context.SaveChanges();
            return checkId;

        }
        public IQueryable<dynamic> SearchByWorkingName(Working working)
        {
            var keyword = _context.Workings.Where(c => c.WorkingName.Contains(working.WorkingName));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchWorkingById(Working working)
        {
            var pzById = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            return pzById;
        }
    }
}
