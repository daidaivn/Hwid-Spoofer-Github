using ApiProject.Models;
using ApiProject.Services;

namespace ApiProject.IServices

{
    public interface IUserServices
    {
        IQueryable<dynamic> getAllUser();
        dynamic CreateUser(User user);
        dynamic CreateUserRole(User user);
        dynamic UpdateUser(User user);
        IQueryable<dynamic> SearchByName(User user);
        dynamic SearchUserById(User user);
    }
}
