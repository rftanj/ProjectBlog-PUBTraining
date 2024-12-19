using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectBlog.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Roles> Role { get; set; }
        public virtual DbSet<Access> Access { get; set; }
    }
}
