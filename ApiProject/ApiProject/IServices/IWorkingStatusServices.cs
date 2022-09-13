using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface IWorkingStatusService
    {
         public IQueryable<dynamic> getAllWorkingStats();
         public dynamic CreateWorkingStatus(WorkingStatus workingStatus);
         public dynamic UpdateWorkingStatus (WorkingStatus workingStatus);
         public IQueryable<dynamic> SearchByWorkingStatusName (WorkingStatus workingStatus);
         public IQueryable<dynamic> SearchByWorkingStatusId (WorkingStatus workingStatus);
    }
}