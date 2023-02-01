using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDiary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeilds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relevanse",
                table: "Target");

            migrationBuilder.AddColumn<bool>(
                name: "relevance",
                table: "Target",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "relevance",
                table: "Target");

            migrationBuilder.AddColumn<int>(
                name: "Relevanse",
                table: "Target",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
