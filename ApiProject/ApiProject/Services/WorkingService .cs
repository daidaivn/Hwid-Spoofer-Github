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
            return _context.Workings;
        }
        public dynamic CreateWorking(Working working)
        {
            Working rl = new Working
            {
                WorkingName = working.WorkingName,
            };
            _context.Workings.Add(rl);
            _context.SaveChanges();
            return rl;
        }
        public dynamic UpdateWorking(Working working)
        {
            var checkId = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            if (checkId == null)
            {
                return false;
            }
            checkId.WorkingName = working.WorkingName;
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
