using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class UWService : IUWService
    {
        private readonly TestTek4TvContext _context;
        public UWService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> GetAllUW()
        {
            var items = _context.Users.Include(c => c.Workings);
            var output = from item in items
                         select new
                         {
                             item.UserId,
                             item.Name,
                             //item.Status,
                             item.Workings
                         };
            return output;
        }
        public dynamic UpdateUW(Working working)
        {
            var obj = _context.Workings.Where(x => x.WorkingId == working.WorkingId)
                .Include(c => c.Users)
                .FirstOrDefault(w => w.WorkingId == working.WorkingId);

            if (obj != null)
            {
                if (obj.Users != null)
                {
                    var users = _context.Users.ToList();
                    foreach (var user in users)
                    {
                        obj.Users.Remove(user);
                    }
                    _context.Update(obj);
                    _context.SaveChanges();
                }

                var lusers = working.Users.ToList();
                foreach (var luser in lusers)
                {
                    var newluser = _context.Users.Where(c => c.UserId == luser.UserId);
                    obj.Users.Add(newluser.FirstOrDefault());

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
        public dynamic CreateUW(Working working)
        {

            Working newUW = new Working()
            { 
                WorkingName = working.WorkingName,
                DateCreate = working.DateCreate,
                Deadline = working.Deadline,
                WorkingStatusId = working.WorkingStatusId,
                PrioritizedId = working.PrioritizedId,
                UserConfirm = working.UserConfirm,
                Description = working.Description
            };
            _context.Workings.Add(newUW);
            _context.SaveChanges();
            var lusers = working.Users.ToList();
            foreach (var luser in lusers)
            {
                var newuser = _context.Users.Where(c => c.UserId == luser.UserId);
                newUW.Users.Add(newuser.FirstOrDefault());

            }
            _context.Update(newUW);
            _context.SaveChanges();
            return newUW;
        }
    }
}
