namespace GreenhouseGlossary.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string CommonName { get; set; } = "";
        public string ScientificName { get; set; } = "";
        public string Description { get; set; } = "";
        public string LightNeeds { get; set; } = "";
        public string WateringNeeds { get; set; } = "";
        public string CareDifficulty { get; set; } = "";
        public string ImagePath { get; set; } = "";
        public string SoilPreferences { get; set; } = "";
        public string CareInstructions { get; set; } = "";
    }
}
