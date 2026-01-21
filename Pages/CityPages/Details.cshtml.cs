using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab3_province_city.Models;
using lab3_province_city.Data;

namespace lab3_province_city.Pages.CityPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

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
}
