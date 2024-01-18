using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Schedules
{
    public class EditModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public EditModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Schedule = await _context.Schedules.FindAsync(id);

            if (Schedule == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var scheduleToUpdate = await _context.Schedules.FindAsync(id);

            if (scheduleToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Schedule>(
                scheduleToUpdate,
                "schedule",
                s => s.DateTime))
            //s=> s.Date,
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleID == id);
        }
    }
}
