using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface IUWService
    {
        IQueryable<dynamic> GetAllUW();
        dynamic UpdateUW(Working working);
        dynamic CreateUW(Working working);
    }
}
