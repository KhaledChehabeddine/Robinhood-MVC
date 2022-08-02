using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace robinhood_mvc.Migrations
{
    public partial class RobinhoodMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Instructor = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Semester = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Instructor", "Name", "Rating", "Semester", "Year" },
                values: new object[] { 1, "Imad Moukadem", "CMPS 278", 5, "Summer", "2021-2022" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Instructor", "Name", "Rating", "Semester", "Year" },
                values: new object[] { 2, "Mahmoud Bdeir", "CMPS 253", 3, "Spring", "2021-2022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
