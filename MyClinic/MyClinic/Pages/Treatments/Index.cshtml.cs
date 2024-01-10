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
    public class IndexModel : PageModel
    {
        private readonly MyClinic.Data.MyClinicContext _context;

        public IndexModel(MyClinic.Data.MyClinicContext context)
        {
            _context = context;
        }

        public IList<Treatment> Treatment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Treatment != null)
            {
                Treatment = await _context.Treatment.ToListAsync();
            }
        }
    }
}
