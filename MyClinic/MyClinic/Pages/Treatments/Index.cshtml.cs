using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Treatments
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
        public string DOBSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Treatment> Treatments { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DOBSort = sortOrder == "DOB" ? "dob_desc" : "DOB";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Treatment> treatmentsIQ = from s in _context.Treatments
                                             select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                treatmentsIQ = treatmentsIQ.Where(s => s.TreatmentName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    treatmentsIQ = treatmentsIQ.OrderByDescending(s => s.TreatmentName);
                    break;
                default:
                    treatmentsIQ = treatmentsIQ.OrderBy(s => s.TreatmentName);
                    break;


            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Treatments = await PaginatedList<Treatment>.CreateAsync(
                treatmentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}