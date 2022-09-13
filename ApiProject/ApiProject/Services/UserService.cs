using ApiProject.Models;
using ApiProject.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var checkId = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);
            if(checkId == null)
            {
                return false;
            }
            else
            {
                checkId.UserId = user.UserId;
                checkId.Name = user.Name;
                checkId.Avatar = user.Avatar;
                checkId.Email = user.Email;
                checkId.Password = user.Password;
                checkId.Address = user.Address;
                checkId.Mobile = user.Mobile;
                checkId.Gender = user.Gender;
                checkId.RoleId = user.RoleId;
                checkId.Status = user.Status;
                _context.Users.Update(checkId);
                _context.SaveChanges();
                return checkId;
            }
        }


    }
}
