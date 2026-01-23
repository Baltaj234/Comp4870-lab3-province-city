using lab3_province_city.Data;
using lab3_province_city.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab3_province_city.Pages.CityPages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.Cities
                .FirstOrDefaultAsync(m => m.CityId == id);

            if (City == null)
            {
                return NotFound();
            }

            
            ViewData["ProvinceCode"] = new SelectList(
                _context.Provinces,
                "ProvinceCode",
                "ProvinceName",
                City.ProvinceCode
            );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               
                ViewData["ProvinceCode"] = new SelectList(
                    _context.Provinces,
                    "ProvinceCode",
                    "ProvinceName",
                    City.ProvinceCode
                );

                return Page();
            }

            _context.Attach(City).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
