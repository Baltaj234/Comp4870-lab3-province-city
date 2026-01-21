using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab3_province_city.Models;
using lab3_province_city.Data;

namespace lab3-province-city.Pages.CityPages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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
        City = city;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(City).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CityExists(City.CityId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool CityExists(int cityid)
    {
        return _context.Cities.Any(e => e.CityId == cityid);
    }
}
