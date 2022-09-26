using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class UserService : IUserServices
    {
        private readonly TestTek4TvContext _context;
        public UserService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> getAllUser()
        {
            var items = _context.Users.Include(u => u.Roles);
            var output = from item in items
                         select new
                         {
                             item.UserId,
                             item.Name,
                             item.Avatar,
                             item.Email,
                             item.Password,
                             item.Address,
                             item.Mobile,
                             item.Status,
                             item.GenderId,
                             item.Gender.GenderName,
                             Roles = from r in item.Roles
                                     select new
                                     {
                                         r.RoleId,
                                         r.RoleName,
                                         r.Status
                                     }
                         };
            return output;
        }

        public IQueryable<dynamic> pagingUsers(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Users.Count() / pageResults);
            var pagingUsers = _context.Users.Skip((page - 1) * (int)pageResults).Take((int)pageResults);

            return pagingUsers.Select(c => new
            {
                c.UserId,
                c.Name,
                c.Avatar,
                c.Email,
                c.Password,
                c.Address,
                c.Mobile,
                c.GenderId,
                c.Gender.GenderName,
                Roles = from r in c.Roles
                        select new
                        {
                            r.RoleId,
                            r.RoleName,
                            r.Status
                        },
                c.Status,
                pageCount
            });
        }
        public dynamic CreateUser(User user)
        {
            User rl = new User
            {
                Name = user.Name,
                Avatar = user.Avatar,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Mobile = user.Mobile,
                GenderId = user.GenderId,
                Status = true,

            };
            _context.Users.Add(rl);
            _context.SaveChanges();
            return rl;
        }


        public dynamic UpdateUserRole(User user)
        {
            var obj = _context.Users.Where(x => x.UserId == user.UserId)
                .Include(r => r.Roles)
                .FirstOrDefault(m => m.UserId == user.UserId);

            if (obj != null)
            {
                if (obj.Roles != null)
                {
                    var roles = _context.Roles.ToList();
                    foreach (var role in roles)
                    {
                        obj.Roles.Remove(role);
                    }
                    _context.Update(obj);
                    _context.SaveChanges();
                }

                var roleIteam = user.Roles.ToList();
                foreach (var rn in roleIteam)
                {
                    var newRole = _context.Roles.Where(r => r.RoleId == rn.RoleId);
                    obj.Roles.Add(newRole.FirstOrDefault());

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
        public dynamic CreateUserRole(User user)
        {
            if (user.Name.Trim().Equals(""))
            {
                return false;
            }
            User rl = new User
            {
                Name = user.Name,
                Avatar = user.Avatar,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Mobile = user.Mobile,
                GenderId = user.GenderId,
                Status = true,
            };
            var roleIteam = user.Roles.ToList();
            foreach (var rn in roleIteam)
            {
                var newRole = _context.Roles.Where(r => r.RoleId == rn.RoleId);
                rl.Roles.Add(newRole.FirstOrDefault());

            }
            _context.Update(rl);
            _context.SaveChanges();
            return rl;
        }


        public dynamic UpdateUser(User user)
        {
            var checkId = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);
            if (checkId == null || user.Name.Trim().Equals(""))
            {
                return false;
            }
            checkId.Name = user.Name;
            checkId.Avatar = user.Avatar;
            checkId.Email = user.Email;
            checkId.Password = user.Password;
            checkId.Address = user.Address;
            checkId.Mobile = user.Mobile;
            checkId.GenderId = user.GenderId;

            _context.Users.Update(checkId);
            _context.SaveChanges();
            return checkId;

        }
        public IQueryable<dynamic> SearchByName(User user, int page)
        {
            var keyword = _context.Users.Where(c => c.Name.Contains(user.Name.Trim()));
            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Users.Count() / pageResults);
            var pagingUsers = keyword.Skip((page - 1) * (int)pageResults).Take((int)pageResults);

            return pagingUsers.Select(c => new
            {
                c.UserId,
                c.Name,
                c.Avatar,
                c.Email,
                c.Password,
                c.Address,
                c.Mobile,
                c.GenderId,
                c.Gender.GenderName,
                Roles = from r in c.Roles
                        select new
                        {
                            r.RoleId,
                            r.RoleName,
                            r.Status
                        },
                c.Status,
                pageCount
            });
        }

        public dynamic SearchUserById(User user, int page)
        {
            var checkId = _context.Users.Include(w => w.Comments).Include(u => u.Workings).Where(c => c.UserId == user.UserId).FirstOrDefault();
            var pageRes = 2f;
            var workings = checkId.Workings.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var comments = checkId.Comments.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var pageCount1 = Math.Ceiling(checkId.Workings.Count() / pageRes);
            var output = new
            {
                checkId.UserId,
                checkId.Name,
                Working = from w in workings
                          select new
                          {
                              w.WorkingId,
                              w.WorkingName,
                              pageCount1,
                          },
                comment = from cmt in comments
                          select new
                          {
                              cmt.Id,
                              cmt.Comment1,
                              work = from w in _context.Comments.Include(c => c.Workings).FirstOrDefault(w => w.Id == cmt.Id).Workings.ToList()
                                     select new
                                     {
                                         w.WorkingId,
                                         w.WorkingName
                                     },
                              
                          }
            };
            return output;
        }


        public dynamic ChangeStatus(User user)
        {
            var checkId = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);

            if (checkId == null)
            {
                return false;
            }
            else
            {
                checkId.Status = !checkId.Status;
                _context.Users.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }
    }
}

