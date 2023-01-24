using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddDishValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationId = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Carbohydrate = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishValue_Specification_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishValue_SpecificationId",
                table: "DishValue",
                column: "SpecificationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishValue");
        }
    }
}
