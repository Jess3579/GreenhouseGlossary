using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenhouseGlossary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LightNeeds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WateringNeeds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoilPreferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "CareDifficulty", "CareInstructions", "CommonName", "Description", "ImagePath", "LightNeeds", "ScientificName", "SoilPreferences", "WateringNeeds" },
                values: new object[,]
                {
                    { 1, "Easy", "Use a pot with drainage holes and avoid leaving it in standing water.", "Spider Plant", "A leafy houseplant with long, arching leaves.", "", "Bright, indirect light", "Chlorophytum comosum", "Well-draining potting mix", "Water when the top inch of soil feels dry." },
                    { 2, "Easy", "Water sparingly and use a container with drainage holes.", "Snake Plant", "An upright houseplant with thick, sword-shaped leaves.", "", "Indirect light", "Dracaena trifasciata", "Well-draining succulent potting mix", "Allow the soil to dry between waterings." },
                    { 3, "Easy", "Trim long vines as needed and avoid soggy soil.", "Golden Pothos", "A trailing houseplant with heart-shaped, variegated leaves.", "", "Bright, indirect light", "Epipremnum aureum", "Well-draining potting mix", "Water when the top inch of soil feels dry." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
