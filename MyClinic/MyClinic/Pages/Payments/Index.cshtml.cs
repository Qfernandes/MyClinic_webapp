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

namespace MyClinic.Pages.Payments
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

        public PaginatedList<Payment> Payments { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Payment> paymentsIQ = from s in _context.Payments
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                paymentsIQ = paymentsIQ.Where(s => s.Patient.FullName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    paymentsIQ = paymentsIQ.OrderByDescending(s => s.paymentStatus);
                    break;
                case "Date":
                    paymentsIQ = paymentsIQ.OrderBy(s => s.Service);
                    break;
                case "date_desc":
                    paymentsIQ = paymentsIQ.OrderByDescending(s => s.Service);
                    break;
                default:
                    paymentsIQ = paymentsIQ.OrderBy(s => s.paymentStatus);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Payments = await PaginatedList<Payment>.CreateAsync(
                paymentsIQ.Include(s => s.Patient).AsNoTracking(), pageIndex ?? 1, pageSize);



        }
    }
}