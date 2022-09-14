using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface IWorkingService
    {
        public IQueryable<dynamic> GetAllWoking();
        public dynamic CreateWoking(Working working);
        public dynamic UpdateWorking(Working working);
        public IQueryable<dynamic> SearchByWorkingName(Working working);
        public dynamic SearchByWorkingId(Working working);
        public dynamic ChangeStatus(Working working);
    }
}
