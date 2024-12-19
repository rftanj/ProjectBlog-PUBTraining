using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBlog.Models;
using Microsoft.AspNetCore.Authorization;
using ProjectBlog.Helper;

namespace ProjectBlog.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class BlogContentController : Controller
    {
        private readonly AppDbContext _context;

        public BlogContentController(AppDbContext c)
        {
            _context = c;
        }
        public IActionResult Index(int? pageNumber)
        {
            
            int pageSize = 3;
            IQueryable<Blog> data = _context.Blog.Where(x => x.Status == true);

            var result = PaginationHelper<Blog>.Create(
                data,
                pageNumber ?? 1,
                pageSize
            );
            return View(result);
        }

        public IActionResult DetailBlog(int Id)
        {
            var Detail = _context.Blog.SingleOrDefault(o => o.Id == Id);
            if (Detail == null)
            {
                return NotFound();
            }
            
            return View(Detail);
        }
    }
}
