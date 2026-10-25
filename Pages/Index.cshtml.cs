using GreenhouseGlossary.Models;
using GreenhouseGlossary.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenhouseGlossary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPlantRepository _plantRepository;

        public IndexModel(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public List<Plant> Plants { get; private set; } = new();

        public async Task OnGetAsync()
        {
            Plants = await _plantRepository.GetAllAsync();
        }
    }
}
