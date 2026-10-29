using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GreenhouseGlossary.Models;

namespace GreenhouseGlossary.Pages.Jessica
{
    public class DetailsModel : PageModel
    {
        private readonly GreenhouseGlossary.Models.PlantContext _context;

        public DetailsModel(GreenhouseGlossary.Models.PlantContext context)
        {
            _context = context;
        }

        public Plant Plant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants.FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }
            else
            {
                Plant = plant;
            }
            return Page();
        }
    }
}
