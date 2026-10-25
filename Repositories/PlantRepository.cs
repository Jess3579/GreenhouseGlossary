using GreenhouseGlossary.Models;
using Microsoft.EntityFrameworkCore;


namespace GreenhouseGlossary.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly PlantContext _context;

        public PlantRepository(PlantContext context)
        {
            _context = context;
        }

        public async Task<List<Plant>> GetAllAsync()
        {
            return await _context.Plants
                .AsNoTracking()
                .OrderBy(plant => plant.CommonName)
                .ToListAsync();
        }

        public async Task<Plant?> GetByIdAsync(int id)
        {
            return await _context.Plants
                .AsNoTracking()
                .FirstOrDefaultAsync(plant => plant.Id == id);
        }
    }
}
