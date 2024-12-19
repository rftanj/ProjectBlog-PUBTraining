using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectBlog.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ProjectBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AccessController : Controller
    {
        private readonly AppDbContext _context;
        IWebHostEnvironment _env;

        public AccessController(AppDbContext c, IWebHostEnvironment env)
        {
            _env = env;
            _context = c;
        }
        public IActionResult Index(int? pageNumber)
        {

            int pageSize = 3;
            IQueryable<Access> data = (from A in _context.Access
                                     join R in _context.Role on A.Role.Id equals R.Id
                                     orderby A.Id               //Kecil Ke Besar
                                                                //orderby A.Id descending  //Dari Besar Ke Kecil
                                     select new Access
                                     {
                                         Id = A.Id,
                                         Username = A.Username,
                                         Name = A.Name,
                                         Password = A.Password,
                                         RoleName = R.Name
                                     });

            var result = PaginationHelper<Access>.Create(
                data,
                pageNumber ?? 1,
                pageSize
            );


            return View(result);
        }

        public IActionResult AddAccess()
        {
            var getRoles = _context.Role.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            ViewBag.SelectListRole = getRoles;
            return View();
        }

        [HttpPost]
        public IActionResult AddAccess([Bind("Id,Username,Name,Password,Role")] UserForm UForm, IFormFile picts)
        {
            if (ModelState.IsValid)
            {
                var getData = new Access
                {
                    Username = UForm.Username,
                    Name = UForm.Name,
                    Password = UForm.Password,
                    Role = _context.Role.FirstOrDefault(x => x.Id == UForm.Role)
                };

                _context.Add(getData);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            var getRoles = _context.Role.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            ViewBag.SelectListRole = getRoles;

            return View();
        }

        public IActionResult UpdateAccess(int Id)
        {
            var getResult = (from A in _context.Access
                             join R in _context.Role on A.Role.Id equals R.Id
                             where A.Id == Id
                             select new Access
                             {
                                 Username = A.Username,
                                 Name = A.Name,
                                 Password = A.Password,
                                 Id = A.Id,
                                 RolessId = R.Id
                             }).SingleOrDefault();

            var getRoles = _context.Role.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            ViewBag.SelectListRole = getRoles;  

            return View(getResult);
        }

        [HttpPost]
        public IActionResult UpdateAccess([Bind("Id,Username,Name,Password,RolessId")] Access dataAccess)
        {
            if (ModelState.IsValid)
            {
                var findAcc = _context.Access.Find(dataAccess.Id);
                if (findAcc != null)
                {
                    findAcc.Username = dataAccess.Username;
                    findAcc.Name = dataAccess.Name;
                    findAcc.Password = dataAccess.Password;
                    findAcc.Role = _context.Role.FirstOrDefault(x => x.Id == dataAccess.RolessId);

                    _context.Update(findAcc);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteAccess(int Id)
        {
            var getAcc = _context.Access.Find(Id);
            if (getAcc == null)
            {
                return NotFound();
            }

            _context.Remove(getAcc);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
