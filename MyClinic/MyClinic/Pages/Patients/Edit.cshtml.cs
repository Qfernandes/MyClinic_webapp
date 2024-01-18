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

namespace MyClinic.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public EditModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients.FindAsync(id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var patientToUpdate = await _context.Patients.FindAsync(id);

            if (patientToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Patient>(
                patientToUpdate,
                "patient",
                s => s.FullName, s => s.DOB, s => s.Gender, s => s.ContactNumber, s => s.Email, s => s.Address, s => s.NextOfKin))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientID == id);
        }
    }
}
