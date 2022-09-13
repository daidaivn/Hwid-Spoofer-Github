using ApiProject.Models;
using ApiProject.IServices;

namespace ApiProject.Services
{
    public class UserService : IUserService
    {
        private readonly TestTek4TvContext _context;
        public UserService(TestTek4TvContext context)
        {
            _context = context;
        }   
        public IQueryable <dynamic> getAllUser()
        {
            return _context.Users;
        }
        public dynamic CreateUser(User user)
        {
            User newUser = new User
            {
                Name = user.Name,
                Avatar = user.Avatar,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Mobile = user.Mobile,
                Gender = user.Gender,
                RoleId = user.RoleId,
                Status = user.Status,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }
        public dynamic UpdateUser(User user)
        {
            return _context.Users.Update(user);
        }

    }
}
