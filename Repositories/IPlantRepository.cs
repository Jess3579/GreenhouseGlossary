using GreenhouseGlossary.Models;

namespace GreenhouseGlossary.Repositories
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetAllAsync();
        Task<Plant?> GetByIdAsync(int id);
    }
}