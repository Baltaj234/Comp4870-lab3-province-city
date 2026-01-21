using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab3_province_city.Models;
using lab3_province_city.Data;

namespace lab3-province-city.Pages.ProvincePages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Province> Province { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Province = await _context.Provinces.ToListAsync();
    }
}
