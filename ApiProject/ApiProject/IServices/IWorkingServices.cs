using ApiProject.Models;


namespace ApiProject.IServices

{
    public interface IWorkingServices
    {
        IQueryable<dynamic> getAllWorking();
        IQueryable<dynamic> pagingWorking(int page);
        dynamic CreateWorking(Working working);
        dynamic UpdateWorking(Working working);
        dynamic UpdateConnect(Working working);
        dynamic CreateConnect(Working working);
        IQueryable<dynamic> SearchByWorkingName(Working working,int page);
        dynamic SearchWorkingById(Working working);
    }
}
