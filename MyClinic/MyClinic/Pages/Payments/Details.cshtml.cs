using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyClinic.Data;
using MyClinic.Models;

namespace MyClinic.Pages.Payments
{
    public class DetailsModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public DetailsModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        public Payment Payment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            Payment = await _context.Payments
                    .Include(t => t.Patient)

                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (Payment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
