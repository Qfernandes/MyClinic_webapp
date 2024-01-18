using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Schedules
{
    public class DetailsModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public DetailsModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        public Schedule Schedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            Schedule = await _context.Schedules
                    .Include(e => e.Patient)
                    .Include(f => f.Assistant)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ScheduleID == id);

            if (Schedule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
