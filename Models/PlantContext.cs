using Microsoft.EntityFrameworkCore;

namespace GreenhouseGlossary.Models
{
    public class PlantContext : DbContext
    {
        public PlantContext(DbContextOptions<PlantContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plant>().HasData(
                new Plant
                {
                    Id = 1,
                    CommonName = "Spider Plant",
                    ScientificName = "Chlorophytum comosum",
                    Description = "A leafy houseplant with long, arching leaves.",
                    LightNeeds = "Bright, indirect light",
                    WateringNeeds = "Water when the top inch of soil feels dry.",
                    CareDifficulty = "Easy",
                    ImagePath = "",
                    SoilPreferences = "Well-draining potting mix",
                    CareInstructions = "Use a pot with drainage holes and avoid leaving it in standing water."
                },
                new Plant
                {
                    Id = 2,
                    CommonName = "Snake Plant",
                    ScientificName = "Dracaena trifasciata",
                    Description = "An upright houseplant with thick, sword-shaped leaves.",
                    LightNeeds = "Indirect light",
                    WateringNeeds = "Allow the soil to dry between waterings.",
                    CareDifficulty = "Easy",
                    ImagePath = "",
                    SoilPreferences = "Well-draining succulent potting mix",
                    CareInstructions = "Water sparingly and use a container with drainage holes."
                },
                new Plant
                {
                    Id = 3,
                    CommonName = "Golden Pothos",
                    ScientificName = "Epipremnum aureum",
                    Description = "A trailing houseplant with heart-shaped, variegated leaves.",
                    LightNeeds = "Bright, indirect light",
                    WateringNeeds = "Water when the top inch of soil feels dry.",
                    CareDifficulty = "Easy",
                    ImagePath = "",
                    SoilPreferences = "Well-draining potting mix",
                    CareInstructions = "Trim long vines as needed and avoid soggy soil."
                }
            );
        }
    }
}