using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Patients
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
        public Patient Patient { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPatient = new Patient();

            if (await TryUpdateModelAsync<Patient>(
                emptyPatient,
                "patient",   // Prefix for form value.
                s => s.FullName, s => s.DOB, s => s.Gender, s => s.ContactNumber, s => s.Email, s => s.Address, s => s.NextOfKin))
            {
                _context.Patients.Add(emptyPatient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
