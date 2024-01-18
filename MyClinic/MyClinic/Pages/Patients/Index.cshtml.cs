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

namespace MyClinic.Pages.Patients
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

        public PaginatedList<Patient> Patients { get; set; }

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

            IQueryable<Patient> patientsIQ = from s in _context.Patients
                                             select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                patientsIQ = patientsIQ.Where(s => s.FullName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    patientsIQ = patientsIQ.OrderByDescending(s => s.FullName);
                    break;
                case "DOB":
                    patientsIQ = patientsIQ.OrderBy(s => s.DOB);
                    break;
                case "dob_desc":
                    patientsIQ = patientsIQ.OrderByDescending(s => s.DOB);
                    break;
                default:
                    patientsIQ = patientsIQ.OrderBy(s => s.FullName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Patients = await PaginatedList<Patient>.CreateAsync(
                patientsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
