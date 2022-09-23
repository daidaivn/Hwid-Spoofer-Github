using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class CommentService : ICommentService
    {
        private readonly TestTek4TvContext _context;
        public CommentService(TestTek4TvContext context)
        {
            _context = context;
        }
        public dynamic GetCurrentPage(int page)
        {
            var pageRes = 2f;
            var comments = _context.Comments.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var pageCount = Math.Ceiling(_context.Comments.Count() / pageRes);
            var output = comments.Select(c => new
            {
                c.Id,
                c.Comment1,
                User = from user in c.Users
                       select new
                       {
                           user.UserId,
                           user.Name,
                       },
                Working = from working in c.Workings
                          select new
                          {
                              working.WorkingId,
                              working.WorkingName,
                          },
                pageCount,
            });
            return output;
        }
        public IQueryable<dynamic> GetAll()
        {
            var items = _context.Comments.Include(c=>c.Users).Include(w=>w.Workings);
            var output = from item in items
                         select new
                         {
                             item.Id,
                             item.Comment1,
                             User = from user in item.Users
                                    select new
                                    {
                                        user.UserId,
                                    },
                             Working = from working in item.Workings 
                                    select new
                                    {
                                        working.WorkingId,
                                        working.WorkingName
                                    }
                         };
            return _context.Comments;
        }
        public dynamic CreateComment (Comment comment)
        {
            Comment newComment = new Comment
            {
                Comment1 = comment.Comment1.Trim()
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();

            var commentUsers = comment.Users.ToList();
            foreach (var commentUser in commentUsers)
            {
                var user = _context.Users.Where(u => u.UserId == commentUser.UserId).FirstOrDefault();
                newComment.Users.Add(user);
            }
            var commentWorkings = comment.Workings.ToList();
            foreach(var commentWorking in commentWorkings)
            {
                var working = _context.Workings.Where(w=>w.WorkingId == commentWorking.WorkingId).FirstOrDefault();
                newComment.Workings.Add(working);
            }
            _context.Update(newComment);
            _context.SaveChanges();
            return newComment;
        }
        public dynamic UpdateComment(Comment comment)
        {
            var checkId = _context.Comments.Where(c => c.Id == comment.Id).FirstOrDefault();
            if (checkId == null)
            {
                return false;
            }
            checkId.Comment1 = comment.Comment1.Trim();
            _context.Update(checkId);
            _context.SaveChanges();
            return checkId;
        }
        public dynamic DeleteComment(Comment comment)
        {
            var checkId = _context.Comments.Where(c => c.Id == comment.Id).FirstOrDefault();
            if (checkId == null)
            {
                return false;
            }
            _context.Remove(checkId);
            _context.SaveChanges();
            return checkId;
        }
        public dynamic SearchById(Comment comment, int page)
        {
            var checkId = _context.Comments.Include(w => w.Workings).Include(u=>u.Users).Where(c => c.Id == comment.Id).FirstOrDefault();
            var pageRes = 2f;
            var workings = checkId.Workings.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var users = checkId.Users.Skip((page - 1) * (int)pageRes).Take((int)pageRes).ToList();
            var pageCount = Math.Ceiling(checkId.Workings.Count() / pageRes);
            var output = new
            {
                checkId.Id,
                checkId.Comment1,
                Working = from w in workings
                          select new
                          {
                              w.WorkingId,
                              w.WorkingName
                          },
                user = from u in users
                       select new
                       {
                           u.UserId,
                           u.Name
                       },
                pageCount,
            };
            return output;
           // return CheckId;
        }
        public dynamic SearchByName(Comment comment,int page)
        {
            var checkId = _context.Comments.Where(c => c.Comment1.Contains(comment.Comment1.Trim())).ToList();

            

            return checkId;
        }
    }
}
