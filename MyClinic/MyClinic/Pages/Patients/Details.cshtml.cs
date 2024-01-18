using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public DetailsModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients
                    .Include(s => s.Treatmentpatients)
                    .Include(e => e.Payments)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.PatientID == id);
            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
