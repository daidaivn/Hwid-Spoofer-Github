using ApiProject.Models;
using ApiProject.IServices;


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
            return _context.Users;
        }
        public dynamic CreateUser(User user)
        {
            var checkId1 = _context.Roles.FirstOrDefault(c => c.RoleId == user.RoleId);
            if (checkId1 == null)
            {
                return false;

            }
            else
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
        }
        public dynamic UpdateUser(User user)
        {
            var checkId2 = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);
            var checkId1 = _context.Roles.FirstOrDefault(c => c.RoleId == user.RoleId);
            if (checkId1 == null || checkId2 == null)
            {
                return false;
            }
            else
            {

                checkId2.UserId = user.UserId;
                checkId2.Name = user.Name;
                checkId2.Avatar = user.Avatar;
                checkId2.Email = user.Email;
                checkId2.Password = user.Password;
                checkId2.Address = user.Address;
                checkId2.Mobile = user.Mobile;
                checkId2.Gender = user.Gender;
                checkId2.RoleId = user.RoleId;
                checkId2.Status = user.Status;
                _context.Users.Update(checkId2);
                _context.SaveChanges();
                return checkId2;
            }
        }
               
        public IQueryable<dynamic> SearchByUserName(User user)
        {
            var keyword = _context.Users.Where(c => c.Name.Contains(user.Name));
            return keyword.ToList().AsQueryable();
        }
        public dynamic SearchByUserId(User user)
        {
            var keyword = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);
            return keyword;
        }
        public dynamic ChangeStatus(User user)
        {
            var a = user.Status;
            var checkId = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);
            if (checkId != null)
            {
                checkId.Status = a;
                _context.Update(checkId);
                return checkId;
            }
            else
            {
                return false;
            }
        }
    }
}

