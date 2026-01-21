using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab3_province_city.Models;
using lab3_province_city.Data;

namespace lab3_province_city.Pages.ProvincePages;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Province Province { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? provincecode)
    {
        if (provincecode is null)
        {
            return NotFound();
        }

        var province = await _context.Provinces.FirstOrDefaultAsync(m => m.ProvinceCode == provincecode);
        if (province is null)
        {
            return NotFound();
        }
        Province = province;
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

        _context.Attach(Province).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProvinceExists(Province.ProvinceCode))
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

    private bool ProvinceExists(string provincecode)
    {
        return _context.Provinces.Any(e => e.ProvinceCode == provincecode);
    }
}
