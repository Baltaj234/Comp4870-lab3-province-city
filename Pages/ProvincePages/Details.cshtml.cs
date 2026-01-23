using lab3_province_city.Data;
using lab3_province_city.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab3_province_city.Pages.ProvincePages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Province Province { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Province = await _context.Provinces
                .Include(p => p.Cities)
                .FirstOrDefaultAsync(p => p.ProvinceCode == id);

            if (Province == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
