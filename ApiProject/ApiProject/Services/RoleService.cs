using ApiProject.IServices;
using ApiProject.Models;

namespace ApiProject.Services
{
    public class RoleService : IRoleServices
    {
        private readonly TestTek4TvContext _context;
        public RoleService(TestTek4TvContext context)
        {
            _context = context;
        }
        public IQueryable<dynamic> getAllRole()
        {
            var items = _context.Roles;
            var output = from item in items
                         select new
                         {
                             item.RoleId,
                             item.RoleName,
                             item.Status,
                         };
            return output;
            //return _context.Roles;
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
