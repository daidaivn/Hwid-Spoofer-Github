using ApiProject.Models;


namespace ApiProject.IServices

{
    public interface IRoleServices
    {
        IQueryable<dynamic> getAllRole();
    }
}
