using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface ICWService
    {
        IQueryable<dynamic> GetAllCW();
        dynamic UpdateCW(Working working);
        dynamic CreateCW(Working working);
    }
}
