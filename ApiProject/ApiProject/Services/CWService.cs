using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class CWService : ICWService
    {
        private readonly TestTek4TvContext _context;
        public CWService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> GetAllCW()
        {
            var items = _context.Categories.Include(c => c.Workings);
            var output = from item in items
                         select new
                         {
                             item.CategoryName,
                             item.CategoryId,
                             item.Status,
                             item.Workings
                         };
            return output;
        }
        public dynamic UpdateCW(Working working)
        {
            var obj = _context.Workings.Where(x => x.WorkingId == working.WorkingId)
                .Include(c => c.Categories)
                .FirstOrDefault(w => w.WorkingId == working.WorkingId);

            if (obj != null)
            {
                if (obj.Categories != null)
                {
                    var cates = _context.Categories.ToList();
                    foreach (var cate in cates)
                    {
                        obj.Categories.Remove(cate);
                    }
                    _context.Update(obj);
                    _context.SaveChanges();
                }

                var lcate = working.Categories.ToList();
                foreach (var lc in lcate)
                {
                    var newlc = _context.Categories.Where(c => c.CategoryId == lc.CategoryId);
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//#pragma warning disable CS8604 // Possible null reference argument.
                    obj.Categories.Add(newlc.FirstOrDefault());
//#pragma warning restore CS8604 // Possible null reference argument.
//#pragma warning restore CS8602 // Dereference of a possibly null reference.

                }
                _context.Update(obj);
                _context.SaveChanges();
                return obj;
            }
            else
            {
                return false;
            }
        }
        public dynamic CreateCW(Working working)
        {

            Working newCW = new Working()
            { 
                //WorkingId = working.WorkingId,
                WorkingName = working.WorkingName,
                DateCreate = working.DateCreate,
                Deadline = working.Deadline,
                WorkingStatusId = working.WorkingStatusId,
                PrioritizedId = working.PrioritizedId,
                UserConfirm = working.UserConfirm,
                Description = working.Description
            };
            _context.Workings.Add(newCW);
            _context.SaveChanges();
            var lcate = working.Categories.ToList();
            foreach (var lc in lcate)
            {
                var newc = _context.Categories.Where(c => c.CategoryId == lc.CategoryId);
                newCW.Categories.Add(newc.FirstOrDefault());

            }
            _context.Update(newCW);
            _context.SaveChanges();
            return newCW;
        }
    }
}
