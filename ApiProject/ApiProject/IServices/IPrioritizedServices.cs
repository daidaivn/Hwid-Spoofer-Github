using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface IPrioritizedServices
    {
        IQueryable<dynamic> getAllPz();
        dynamic CreatePz(Prioritized prioritized);
        dynamic UpdatePz(Prioritized prioritized);
        dynamic ChangeStatus(Prioritized prioritized);
        IQueryable<dynamic> SearchByPzName(Prioritized prioritized);
        dynamic SearchPzById(Prioritized prioritized);
    }
}
