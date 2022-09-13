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

        public IQueryable<dynamic> getAllPz()
        {
            return _context.Prioritizeds;
        }
        public dynamic CreatePz(Prioritized prioritized)
        {
            Prioritized rl = new Prioritized
            {
                PrioritizedName = prioritized.PrioritizedName,
            };
            _context.Prioritizeds.Add(rl);
            _context.SaveChanges();
            return rl;
        }
        public dynamic UpdatePz(Prioritized prioritized)
        {
            var checkId = _context.Prioritizeds.FirstOrDefault(c => c.PrioritizedId == prioritized.PrioritizedId);
            if (checkId == null)
            {
                return false;
            }
            checkId.PrioritizedName = prioritized.PrioritizedName;
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