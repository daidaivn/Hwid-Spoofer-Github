using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiProject.Services
{
    public class PrioritizedService : IPrioritizedServices
    {
        private readonly TestTek4TvContext _context;

        public PrioritizedService(TestTek4TvContext context)
        {
            _context = context;
        }

        public dynamic GetCurrentPage(int page)
        {
            var pageRes = 2f;
            var prioritizeds = _context.Prioritizeds.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var pageCount = Math.Ceiling(_context.Prioritizeds.Count() / pageRes);
            var output = prioritizeds.Select(c => new
            {
                c.PrioritizedId,
                c.PrioritizedName,
                c.Status,
                pageCount,
            });
            return output;
        }
        public IQueryable<dynamic> getAllPz()
        {
            var items = _context.Prioritizeds.Include(p=>p.Workings);
            var output = from item in items
                         select new
                         {
                             item.PrioritizedId,
                             item.PrioritizedName,
                             item.Status,
                             //Workings = from w in item.Workings
                             //           select new
                             //           {
                             //               w.WorkingId,
                             //           }
                         };
            return output;
            //return _context.Prioritizeds;
        }
        public dynamic CreatePz(Prioritized prioritized)
        {
            if (prioritized.PrioritizedName.Trim().Equals(""))
            {
                return false;
            }
            Prioritized rl = new Prioritized
            {
                PrioritizedName = prioritized.PrioritizedName.Trim(),
                Status = true,
            };
            _context.Prioritizeds.Add(rl);
            _context.SaveChanges();
            return rl;
        }
        public dynamic UpdatePz(Prioritized prioritized)
        {
            var checkId = _context.Prioritizeds.FirstOrDefault(c => c.PrioritizedId == prioritized.PrioritizedId);
            if (checkId == null|| prioritized.PrioritizedName.Trim().Equals(""))
            {
                return false;
            }
            checkId.PrioritizedName = prioritized.PrioritizedName.Trim();
            checkId.Status = prioritized.Status;
            _context.Prioritizeds.Update(checkId);
            _context.SaveChanges();
            return checkId;

        }
        public dynamic ChangeStatus (Prioritized prioritized)
        {
            var checkId = _context.Prioritizeds.FirstOrDefault(c => c.PrioritizedId == prioritized.PrioritizedId);
            if (checkId == null)
            {
                return false;
            }
            checkId.Status = !checkId.Status;
            _context.Prioritizeds.Update(checkId);
            _context.SaveChanges();
            return checkId;
        }
        public IQueryable<dynamic> SearchByPzName(Prioritized prioritized)
        {
            var keyword = _context.Prioritizeds.Where(c => c.PrioritizedName.Contains(prioritized.PrioritizedName));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchPzById(Prioritized prioritized)
        {
            var pzById = _context.Prioritizeds.FirstOrDefault(c => c.PrioritizedId == prioritized.PrioritizedId);
            return pzById;
        }

    }
}