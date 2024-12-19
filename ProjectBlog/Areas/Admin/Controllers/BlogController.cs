using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBlog.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ProjectBlog.Helper;

namespace ProjectBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        IWebHostEnvironment _env;

        public BlogController(AppDbContext c, IWebHostEnvironment env)
        {
            _context = c;
            _env = env;
        }
        public IActionResult Index(int? pageNumber)
        {
            int pageSize = 3;
            IQueryable<Blog> data = _context.Blog;

            var result = PaginationHelper<Blog>.Create(
                data,
                pageNumber ?? 1,
                pageSize
            );
            
            return View(result);
        }

        public IActionResult Iddd()
        {
            var GetData = _context.Blog.Find();

            return View(GetData);
        }

        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog([Bind("Title,Content,Author,Status")] Blog getBlog, IFormFile Picture)
        {
            if (ModelState.IsValid)
            {

                if (Picture != null)
                {
                    string fileName = Picture.FileName;
                    string filePath = Path.Combine(_env.WebRootPath, "uploads/img");
                    string fullPath = Path.Combine(filePath, fileName);
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                   
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }
                   
                    getBlog.Picture = Picture.FileName;
                }


                getBlog.CreatedDate = DateTime.Now;

                _context.Add(getBlog);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UpdateBlog(int Id)
        {
            var getBlogData = _context.Blog.Find(Id);
            return View(getBlogData);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog([Bind("Id,Title,Content,Author,CreatedDate,Status")] Blog blog, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                var findBlog = _context.Blog.Find(blog.Id);
                if (findBlog == null)
                {
                    return NotFound();
                }

                if (Image != null)
                {
                    string fileName = Image.FileName;
                    string filePath = Path.Combine(_env.WebRootPath, "uploads/img");
                    string fullPath = Path.Combine(filePath, fileName);
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }

                    findBlog.Picture = Image.FileName;
                }

                findBlog.Title = blog.Title;
                findBlog.Content = blog.Content;
                findBlog.Author = blog.Author;
                findBlog.CreatedDate = blog.CreatedDate;
                findBlog.Status = blog.Status;

                _context.Update(findBlog);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            var getBlogData = _context.Blog.Find(blog.Id);
            return View(getBlogData);
        }

        [HttpPost]
        public IActionResult DeleteBlog(int id)
        {
            var BlogData = _context.Blog.Find(id);

            if (BlogData == null)
            {
                return NotFound();
            }

            _context.Remove(BlogData);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
