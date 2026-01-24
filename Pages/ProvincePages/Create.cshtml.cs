using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab3_province_city.Models;
using lab3_province_city.Data;

namespace lab3_province_city.Pages.ProvincePages;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Province Province { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
{
    if (!ModelState.IsValid)
    {
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine("MODEL ERROR: " + error.ErrorMessage);
        }

        return Page();
    }

    _context.Provinces.Add(Province);
    await _context.SaveChangesAsync();

    return RedirectToPage("./Index");
}

}
