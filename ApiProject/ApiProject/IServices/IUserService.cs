using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface IUserServices
    {
        public IQueryable<dynamic> getAllUser();
        public dynamic CreateUser(User user);
        public dynamic UpdateUser(User user);
        public IQueryable<dynamic> SearchByUserName(User user);
        public dynamic SearchByUserId(User user);
        public dynamic ChangeStatus(User user);
    }
}
