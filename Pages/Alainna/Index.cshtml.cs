using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GreenhouseGlossary.Models;

namespace GreenhouseGlossary.Pages.Alainna
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
        public string? LightFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? DifficultyFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; } = "common_asc";

        public List<string> LightOptions { get; set; } = new();

        public List<string> DifficultyOptions { get; set; } = new();

        public async Task OnGetAsync()
        {
            LightOptions = await _context.Plants
                .Where(p => p.LightNeeds != null && p.LightNeeds != "")
                .Select(p => p.LightNeeds!)
                .Distinct()
                .OrderBy(light => light)
                .ToListAsync();

            DifficultyOptions = await _context.Plants
                .Where(p => p.CareDifficulty != null && p.CareDifficulty != "")
                .Select(p => p.CareDifficulty!)
                .Distinct()
                .OrderBy(difficulty => difficulty)
                .ToListAsync();

            IQueryable<Plant> plants = _context.Plants;

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                string search = SearchString.Trim();

                plants = plants.Where(p =>
                    (p.CommonName != null &&
                     p.CommonName.Contains(search)) ||
                    (p.ScientificName != null &&
                     p.ScientificName.Contains(search)));
            }

            if (!string.IsNullOrWhiteSpace(LightFilter))
            {
                plants = plants.Where(p =>
                    p.LightNeeds == LightFilter);
            }

            if (!string.IsNullOrWhiteSpace(DifficultyFilter))
            {
                plants = plants.Where(p =>
                    p.CareDifficulty == DifficultyFilter);
            }

            plants = SortOrder switch
            {
                "common_desc" =>
                    plants.OrderByDescending(p => p.CommonName),

                "scientific_asc" =>
                    plants.OrderBy(p => p.ScientificName),

                "scientific_desc" =>
                    plants.OrderByDescending(p => p.ScientificName),

                _ =>
                    plants.OrderBy(p => p.CommonName)
            };

            Plant = await plants.ToListAsync();
        }
    }
}