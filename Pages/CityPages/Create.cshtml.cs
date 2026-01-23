using lab3_province_city.Data;
using lab3_province_city.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3_province_city.Pages.CityPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["ProvinceCode"] = new SelectList(
                _context.Provinces,
                "ProvinceCode",
                "ProvinceName"
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
            "ProvinceName"
        );

        return Page();
    }

    _context.Cities.Add(City);
    await _context.SaveChangesAsync();

    return RedirectToPage("./Index");
}

    }
}
