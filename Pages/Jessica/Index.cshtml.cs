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
    public class IndexModel : PageModel
    {
        private readonly GreenhouseGlossary.Models.PlantContext _context;

        public IndexModel(GreenhouseGlossary.Models.PlantContext context)
        {
            _context = context;
        }

        public IList<Plant> Plant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Plant = await _context.Plants.ToListAsync();
        }
    }
}
