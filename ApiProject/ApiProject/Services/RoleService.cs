using ApiProject.IServices;
using ApiProject.Models;
using System.Runtime.CompilerServices;

namespace ApiProject.Services
{
    public class RoleService : IRoleServices
    {
        private readonly TestTek4TvContext _context;
        public RoleService(TestTek4TvContext context)
        {
            _context = context;
        }

        public IQueryable<dynamic> getAllRole(int page)
        {
            
            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Roles.Count() / pageResults);
            var role2s = _context.Roles.Skip((page - 1) * (int)pageResults).Take((int)pageResults);

            return role2s.Select(c => new { 
                c.RoleId,
                c.RoleName,
                c.Status,
            });
        }


        public dynamic CreateRole(Role role)
        {
            if (role.RoleName.Trim().Equals(""))
            {
                return false;
            }
            Role rl = new Role
            {
                RoleName = role.RoleName.Trim(),
                Status = true,
            };
            _context.Roles.Add(rl);
            _context.SaveChanges();
            return rl;
        }
        public dynamic UpdateRole(Role role)
        {
            var checkId = _context.Roles.FirstOrDefault(c => c.RoleId == role.RoleId);
            if (checkId == null || role.RoleName.Trim().Equals(""))
            {
                return false;
            }
            checkId.RoleName = role.RoleName.Trim();
            _context.Roles.Update(checkId);
            _context.SaveChanges();
            return checkId;

        }
        public dynamic ChangeStatus (Role role)
        {
            var checkId = _context.Roles.FirstOrDefault(c => c.RoleId == role.RoleId);
            if (checkId == null)
            {
                return false;
            }
            checkId.Status =! checkId.Status;
            _context.Roles.Update(checkId);
            _context.SaveChanges();
            return checkId;
        }
        public IQueryable<dynamic> SearchByRoleName(Role role)
        {
            var keyword = _context.Roles.Where(c => c.RoleName.Contains(role.RoleName.Trim()));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchRoleById(Role role)
        {
            var pzById = _context.Roles.FirstOrDefault(c => c.RoleId == role.RoleId);
            return pzById;
        }
    }
}
