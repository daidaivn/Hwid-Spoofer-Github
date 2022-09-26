using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            var items = _context.Workings.Include(w1 => w1.Categories).Include(w2 => w2.Users);
            var output = from item in items
                         select new
                         {
                             item.WorkingId,
                             item.WorkingName,
                             item.DateCreate,
                             item.Deadline,
                             item.WorkingStatus,
                             item.Prioritized,
                             Category = from c in item.Categories
                                        select new
                                        {
                                            c.CategoryId,
                                            c.CategoryName,
                                        },
                             item.UserConfirm,
                             item.Description,
                             user = from u in item.Users select new
                                    {
                                        u.UserId,
                                        u.Name,
                                    },
                             comment = from cm in item.Comments select new
                                       {
                                            cm.Id,
                                            cm.Comment1,
                                       },
                                       
                         };
            return output;
        }
        public IQueryable<dynamic> pagingWorking(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Workings.Count() / pageResults);
            var pagingWorking = _context.Workings.Skip((page - 1) * (int)pageResults).Take((int)pageResults);

            return pagingWorking.Select(c => new
            {
                c.WorkingId,
                c.WorkingName,
                c.DateCreate,
                c.Deadline,
                c.WorkingStatus,
                c.Prioritized,
                Category = from d in c.Categories
                           select new
                           {
                               d.CategoryId,
                               d.CategoryName,
                           },
                c.UserConfirm,
                c.Description,
                user = from u in c.Users
                       select new
                       {
                           u.UserId,
                           u.Name,
                       },
                comment = from cm in c.Comments
                          select new
                          {
                              cm.Id,
                              cm.Comment1,
                          },
            });
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
                DateCreate = DateTime.Now,
                Deadline = working.Deadline,
                WorkingStatusId = 1,
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
            checkId.DateCreate =DateTime.Now;
            checkId.Deadline = working.Deadline;
            checkId.WorkingStatusId = working.WorkingStatusId;
            checkId.PrioritizedId = working.PrioritizedId;
            checkId.UserConfirm = working.UserConfirm;
            checkId.Description = working.Description;
            _context.Workings.Update(checkId);
            _context.SaveChanges();
            return checkId;

        }
        public dynamic UpdateConnect(Working working)
        {
            var obj = _context.Workings.Where(x => x.WorkingId == working.WorkingId)
                .Include(c => c.Categories)
                .Include(u => u.Users)
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
                var lcate = working.Categories.ToList();
                foreach (var lc in lcate)
                {
                    var newlc = _context.Categories.Where(c => c.CategoryId == lc.CategoryId);
                    obj.Categories.Add(newlc.FirstOrDefault());
                }
                _context.Update(obj);
                _context.SaveChanges();
                var lusers = working.Users.ToList();
                foreach (var lu in lusers)
                {
                    var newuser = _context.Users.Where(u => u.UserId == lu.UserId);
                    obj.Users.Add(newuser.FirstOrDefault());
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
        public dynamic CreateConnect(Working working)
        {
            if (working.WorkingName.Trim().Equals(""))
            {
                return false;
            }
            Working newWorking = new Working()
            {
                //WorkingId = working.WorkingId,
                WorkingName = working.WorkingName.Trim(),
                DateCreate = DateTime.Now,
                Deadline = working.Deadline,
                WorkingStatusId = 1,
                PrioritizedId = working.PrioritizedId,
                UserConfirm = working.UserConfirm,
                Description = working.Description
            };
            _context.Workings.Add(newWorking);
            _context.SaveChanges();
            var lcate = working.Categories.ToList();
            foreach (var lc in lcate)
            {
                var newc = _context.Categories.Where(c => c.CategoryId == lc.CategoryId);
                newWorking.Categories.Add(newc.FirstOrDefault());
            }
            var lusers = working.Users.ToList();
            foreach (var luser in lusers)
            {
                var newuser = _context.Users.Where(c => c.UserId == luser.UserId);
                newWorking.Users.Add(newuser.FirstOrDefault());
            }
            _context.Update(newWorking);
            _context.SaveChanges();
            return newWorking;
        }
        public IQueryable<dynamic> SearchByWorkingName(Working working,int page)
        {
            var keyword = _context.Workings.Where(c => c.WorkingName.Contains(working.WorkingName.Trim()));

            var pageResults = 2f;
            var pageCount = Math.Ceiling(keyword.Count() / pageResults);
            var pagingWorking = keyword.Skip((page - 1) * (int)pageResults).Take((int)pageResults);
            //var pagingComment = keyword.Skip((page - 1) * (int)pageResults).Take((int)pageResults);
            var items = pagingWorking.Include(w1 => w1.Categories).Include(w2 => w2.Users).Include(w3=>w3.Comments);
            var output = from item in items
                         select new
                         {
                             item.WorkingId,
                             item.WorkingName,
                             item.DateCreate,
                             item.Deadline,
                             item.WorkingStatus,
                             item.Prioritized,
                             pageCount,
                             Category = from c in item.Categories
                                        select new
                                        {
                                            c.CategoryId,
                                            c.CategoryName,
                                        },
                             item.UserConfirm,
                             item.Description,
                             user = from u in item.Users
                                    select new
                                    {
                                        u.UserId,
                                        u.Name,
                                    },
                             //comment = from cm in item.Comments
                             //          select new
                             //          {
                             //              cm.Id,
                             //              cm.Comment1,
                             //          },

                         };
            return output;
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchWorkingById(Working working)
        {
            var pzById = _context.Workings.FirstOrDefault(c => c.WorkingId == working.WorkingId);
            return pzById;
        }
    }
}
