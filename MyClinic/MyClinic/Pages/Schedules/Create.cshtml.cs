using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Schedules
{
    public class CreateModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public CreateModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Schedule Schedule { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySchedule = new Schedule();

            if (await TryUpdateModelAsync<Schedule>(
                emptySchedule,
                "schedule",   // Prefix for form value.
                s => s.DateTime))
            {
                _context.Schedules.Add(emptySchedule);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
