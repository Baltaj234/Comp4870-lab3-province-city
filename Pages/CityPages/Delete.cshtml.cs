using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab3_province_city.Models;
using lab3_province_city.Data;

namespace lab3_province_city.Pages.CityPages;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public City City { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? cityid)
    {
        if (cityid is null)
        {
            return NotFound();
        }

        var city = await _context.Cities.FirstOrDefaultAsync(m => m.CityId == cityid);
        if (city is null)
        {
            return NotFound();
        }
        else
        {
            City = city;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? cityid)
    {
        if (cityid is null)
        {
            return NotFound();
        }

        var city = await _context.Cities.FindAsync(cityid);
        if (city != null)
        {
            City = city;
            _context.Cities.Remove(City);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
