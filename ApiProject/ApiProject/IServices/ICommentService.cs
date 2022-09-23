using ApiProject.Models;

namespace ApiProject.IServices
{
    public interface ICommentService
    {
        public dynamic GetCurrentPage(int page);
        IQueryable<dynamic> GetAll();
        public dynamic CreateComment(Comment comment);
        public dynamic UpdateComment(Comment comment);
        public dynamic DeleteComment(Comment comment);
        public dynamic SearchById(Comment comment, int page);
        public dynamic SearchByName(Comment comment,int page);
    }
}
