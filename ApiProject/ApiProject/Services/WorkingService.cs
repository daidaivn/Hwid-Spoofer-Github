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
    }
}
