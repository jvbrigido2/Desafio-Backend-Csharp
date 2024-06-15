using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scraping.Infrastructure.Migrations
{
    public partial class UpdateComponentReferencesType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValuePer100g = table.Column<double>(type: "float", nullable: false),
                    StandardDeviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDataUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    References = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodItemCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_FoodItems_FoodItemCode",
                        column: x => x.FoodItemCode,
                        principalTable: "FoodItems",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_FoodItemCode",
                table: "Components",
                column: "FoodItemCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "FoodItems");
        }
    }
}
