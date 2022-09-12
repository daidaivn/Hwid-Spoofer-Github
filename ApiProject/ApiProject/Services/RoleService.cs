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
            return _context.Roles;
        }


    }
}
