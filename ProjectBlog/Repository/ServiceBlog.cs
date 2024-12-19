using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectBlog.Models;
using ProjectBlog.Models.DataTable;
using ProjectBlog.Models.DTO;
using ProjectBlog.Helper;

namespace ProjectBlog.Repository
{
    public class ServiceBlog
    {
        private AppDbContext _AppDBContext;

        public ServiceBlog(AppDbContext context)
        {
            _AppDBContext = context;
        }

        public DataTableResult DataTableBio(int start, int pageSize, string order, string orderType, Dictionary<string, string> search)
        {
            Expression<Func<Bio, bool>> whereClause = x => true
                && (search["Name"] == null || x.Name.Contains(search["Name"]))
                && (search["Address"] == null || x.Address.Contains(search["Address"]))
                && (search["Nickname"] == null || x.Nickname.Contains(search["Nickname"]))
                && (search["Status"] == null || search["Status"] == "All" || x.Status == (DocumentStatus)Enum.Parse(typeof(DocumentStatus), search["Status"]))
                && x.Status != DocumentStatus.Deleted;

            var data = _AppDBContext.Bios
                .Where(whereClause)
                .Select(x => new BioDTO()
                {
                    Name = x.Name,
                    Address = x.Address,
                    Nickname = x.Nickname,
                    Status = x.Status.ToString()
                });

            if (order != "Status")
            {
                if (orderType == "asc")
                    data = data.OrderBy(order);
                else
                    data = data.OrderByDescending(order);
            }

            data = data.Skip(start).Take(pageSize);

            int totalResultCount = _AppDBContext.Bios.Where(x => x.Status != DocumentStatus.Deleted).Count();
            int totalFilteredResultCounts = _AppDBContext.Bios.Where(whereClause).Count();
            return new DataTableResult(data.ToList(), totalResultCount, totalFilteredResultCounts);
        }
    }
}
