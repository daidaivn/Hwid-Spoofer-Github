using ApiProject.IServices;
using ApiProject.Models;
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
                             item.GenderId,
                             item.Gender.GenderName,
                             //item.Roles
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
            if (checkId == null)
            {
                return false;
            }
            checkId.Name = user.Name;
            _context.Users.Update(checkId);
            _context.SaveChanges();
            return checkId;

        }
        public IQueryable<dynamic> SearchByName(User user)
        {
            var keyword = _context.Users.Where(c => c.Name.Contains(user.Name));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchUserById(User user)
        {
            var pzById = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);
            return pzById;
        }
    }

    public class UserRole
    {
        public int UserId { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
