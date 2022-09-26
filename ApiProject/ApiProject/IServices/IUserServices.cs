using ApiProject.Models;
using ApiProject.Services;

namespace ApiProject.IServices

{
    public interface IUserServices
    {
        IQueryable<dynamic> getAllUser();
        IQueryable<dynamic> pagingUsers(int page);
        dynamic CreateUser(User user);
        dynamic CreateUserRole(User user);
        dynamic UpdateUserRole(User user);
        dynamic UpdateUser(User user);
        IQueryable<dynamic> SearchByName(User user,int page);
        dynamic SearchUserById(User user, int  page);
        dynamic ChangeStatus(User user);
    }
}
