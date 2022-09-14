using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface IWorkingService
    {
        public IQueryable<dynamic> GetAllWoking();
        public dynamic CreateWoking(Working working);
    }
}
