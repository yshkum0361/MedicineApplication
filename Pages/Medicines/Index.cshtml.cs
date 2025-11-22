using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicineApplication.Data;
using MedicineApplication.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MedicineApplication.Pages_Medicines
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Medicine> Medicine { get; set; } = default!;

        // Pagination Properties
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10; // Items per page

        // Sorting/Filtering Properties
        [BindProperty(SupportsGet = true)]
        public string? CurrentFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentSort { get; set; } = "Name"; // Default sort

        public async Task OnGetAsync(int pageIndex = 1, string? searchString = null, string? sortOrder = null)
        {
            // Update filter and sorting state
            CurrentFilter = searchString ?? CurrentFilter;
            CurrentSort = sortOrder ?? CurrentSort;
            PageIndex = pageIndex < 1 ? 1 : pageIndex;

            IQueryable<Medicine> medicinesIQ = _context.Medicines.AsNoTracking();

            // 1. Filtering/Search
            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                medicinesIQ = medicinesIQ.Where(m => m.Name.Contains(CurrentFilter)
                                       || m.Company.Contains(CurrentFilter));
            }

            // 2. Sorting
            medicinesIQ = CurrentSort switch
            {
                "Name_desc" => medicinesIQ.OrderByDescending(m => m.Name),
                "Price" => medicinesIQ.OrderBy(m => m.Price),
                "Price_desc" => medicinesIQ.OrderByDescending(m => m.Price),
                "ExpiryDate" => medicinesIQ.OrderBy(m => m.ExpiryDate),
                "ExpiryDate_desc" => medicinesIQ.OrderByDescending(m => m.ExpiryDate),
                _ => medicinesIQ.OrderBy(m => m.Name),
            };

            // 3. Pagination
            var count = await medicinesIQ.CountAsync();
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            Medicine = await medicinesIQ
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
