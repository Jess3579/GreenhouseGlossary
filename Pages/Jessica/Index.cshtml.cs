using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GreenhouseGlossary.Models;

namespace GreenhouseGlossary.Pages.Jessica
{
    public class IndexModel : PageModel
    {
        private readonly PlantContext _context;

        public IndexModel(PlantContext context)
        {
            _context = context;
        }

        public IList<Plant> Plant { get; set; } = new List<Plant>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Difficulty { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        public async Task OnGetAsync()
        {
            var plants = _context.Plants.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                SearchString = SearchString.Trim();

                plants = plants.Where(p =>
                    p.CommonName.Contains(SearchString));
            }

            if (!string.IsNullOrWhiteSpace(Difficulty))
            {
                plants = plants.Where(p =>
                    p.CareDifficulty == Difficulty);
            }

            if (SortOrder == "name_desc")
            {
                plants = plants.OrderByDescending(p => p.CommonName);
            }
            else
            {
                plants = plants.OrderBy(p => p.CommonName);
            }

            Plant = await plants.ToListAsync();
        }
    }
}
