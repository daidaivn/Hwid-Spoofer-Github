using ApiProject.Models;


namespace ApiProject.IServices

{
    public interface IRoleServices
    {
        IQueryable<dynamic> getAllRole();
        IQueryable<dynamic> pagingRole(int page);
        dynamic CreateRole(Role role);
        dynamic UpdateRole(Role role);
        dynamic ChangeStatus(Role role);
        IQueryable<dynamic> SearchByRoleName(Role role);
        dynamic SearchRoleById(Role role);
    }
}
