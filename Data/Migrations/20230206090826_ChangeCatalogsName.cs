using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDiary.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCatalogsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PhysicalActivityCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalActivityCatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SexCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SexCatalog", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PhysicalActivityCatalog_PhysicalActivityId",
                table: "AspNetUsers",
                column: "PhysicalActivityId",
                principalTable: "PhysicalActivityCatalog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SexCatalog_SexId",
                table: "AspNetUsers",
                column: "SexId",
                principalTable: "SexCatalog",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PhysicalActivityCatalog_PhysicalActivityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SexCatalog_SexId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PhysicalActivityCatalog");

            migrationBuilder.DropTable(
                name: "SexCatalog");

            migrationBuilder.CreateTable(
                name: "PhysicalActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
    }
}
