using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface IWorkingStatusService
    {
        public IQueryable<dynamic> getAllWorkingStatus();
        IQueryable<dynamic> pagingWorkingStatus(int page);
        public dynamic CreateWorkingStatus(WorkingStatus workingStatus);
        public dynamic UpdateWorkingStatus(WorkingStatus workingStatus);
        public IQueryable<dynamic> SearchByWorkingStatusName(WorkingStatus workingStatus);
        public dynamic SearchByWorkingStatusId(WorkingStatus workingStatus);
        dynamic ChangeStatus(WorkingStatus workingStatus);
    }
}