using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyClinic;
using MyClinic.Data;
using MyClinic.Models;
using MyClinic.Pages;
using System.Configuration;

namespace MyClinic.Pages.Schedules
{

    public class IndexModel : PageModel
    {
        private readonly MyClinicContext _context;

        private readonly IConfiguration Configuration;

        public IndexModel(MyClinicContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string DateTimeSort { get; set; }

        public PaginatedList<Schedule> Schedules { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            DateTimeSort = sortOrder == "DateTime" ? "datetime_desc" : "DateTime";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Schedule> schedulesIQ = from s in _context.Schedules
                                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                schedulesIQ = schedulesIQ.Where(s => s.Patient.FullName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    schedulesIQ = schedulesIQ.OrderByDescending(s => s.Paymentstatus);
                    break;
                case "Date":
                    schedulesIQ = schedulesIQ.OrderBy(s => s.Service);
                    break;
                case "DateTime":
                    schedulesIQ = schedulesIQ.OrderBy(s => s.DateTime);
                    break;
                case "date_desc":
                    schedulesIQ = schedulesIQ.OrderByDescending(s => s.Service);
                    break;
                case "datetime_desc":
                    schedulesIQ = schedulesIQ.OrderByDescending(s => s.DateTime);
                    break;
                default:
                    schedulesIQ = schedulesIQ.OrderBy(s => s.Paymentstatus);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Schedules = await PaginatedList<Schedule>.CreateAsync(
                schedulesIQ.Include(s => s.Patient).Include(f => f.Assistant).AsNoTracking(), pageIndex ?? 1, pageSize);



        }
    }
}