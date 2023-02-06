using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderandPhyssicalActivityEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PhysicalActivityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SexId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhysicalActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhysicalActivityId",
                table: "AspNetUsers",
                column: "PhysicalActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SexId",
                table: "AspNetUsers",
                column: "SexId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PhysicalActivity_PhysicalActivityId",
                table: "AspNetUsers",
                column: "PhysicalActivityId",
                principalTable: "PhysicalActivity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sex_SexId",
                table: "AspNetUsers",
                column: "SexId",
                principalTable: "Sex",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PhysicalActivity_PhysicalActivityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sex_SexId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PhysicalActivity");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhysicalActivityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SexId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhysicalActivityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SexId",
                table: "AspNetUsers");
        }
    }
}
