using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Treatments
{
    public class DetailsModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public DetailsModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

      public Treatment Treatment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Treatments == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatments.FirstOrDefaultAsync(m => m.TreatmentID == id);
            if (treatment == null)
            {
                return NotFound();
            }
            else 
            {
                Treatment = treatment;
            }
            return Page();
        }
    }
}
