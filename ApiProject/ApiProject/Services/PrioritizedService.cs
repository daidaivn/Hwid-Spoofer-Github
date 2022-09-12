using ApiProject.IServices;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Services
{
    public class PrioritizedService : IPrioritizedSevices
    {
        private readonly TestTek4TvContext _context;

        public PrioritizedService(TestTek4TvContext context)
        {
            _context = context;
        }
    }
}
