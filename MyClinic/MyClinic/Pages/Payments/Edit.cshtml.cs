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

namespace MyClinic.Pages.Payments
{
    public class EditModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public EditModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment = await _context.Payments
                .Include(s => s.Treatmentpatients)
                .Include(t => t.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PaymentID == id);

            //Payment = await _context.Payments.FindAsync(id);

            if (Payment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var paymentToUpdate = await _context.Payments.FindAsync(id);

            if (paymentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Payment>(
                paymentToUpdate,
                "payment",
                s => s.paymentStatus))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
