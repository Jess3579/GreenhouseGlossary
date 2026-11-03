using System.ComponentModel.DataAnnotations;

namespace GreenhouseGlossary.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the plant's common name.")]
        [Display(Name = "Common name")]
        public string CommonName { get; set; } = "";

        [Required(ErrorMessage = "Please enter the scientific name.")]
        [Display(Name = "Scientific name")]
        public string ScientificName { get; set; } = "";

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Please enter the plant's light needs.")]
        [Display(Name = "Light needs")]
        public string LightNeeds { get; set; } = "";

        [Required(ErrorMessage = "Please enter the plant's watering needs.")]
        [Display(Name = "Watering needs")]
        public string WateringNeeds { get; set; } = "";

        [Required(ErrorMessage = "Please select a care difficulty.")]
        [RegularExpression(
            "^(Easy|Moderate|Difficult)$",
            ErrorMessage = "Choose Easy, Moderate, or Difficult.")]
        [Display(Name = "Care difficulty")]
        public string CareDifficulty { get; set; } = "";

        [Display(Name = "Image path")]
        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "Please enter the soil preferences.")]
        [Display(Name = "Soil preferences")]
        public string SoilPreferences { get; set; } = "";

        [Required(ErrorMessage = "Please enter care instructions.")]
        [Display(Name = "Care instructions")]
        public string CareInstructions { get; set; } = "";
    }
}
