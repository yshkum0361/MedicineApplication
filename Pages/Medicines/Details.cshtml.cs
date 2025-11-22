using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicineApplication.Data;
using MedicineApplication.Models;

namespace MedicineApplication.Pages_Medicines
{
    public class DetailsModel : PageModel
    {
        private readonly MedicineApplication.Data.ApplicationDbContext _context;

        public DetailsModel(MedicineApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Medicine Medicine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicines.FirstOrDefaultAsync(m => m.MedicineId == id);
            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                Medicine = medicine;
            }
            return Page();
        }
    }
}
