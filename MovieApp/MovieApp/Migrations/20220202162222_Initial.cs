using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    movieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<string>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentto = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.movieID);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Romance" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Action" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Comedy" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieID", "CategoryID", "director", "edited", "lentto", "notes", "rating", "title", "year" },
                values: new object[] { 1, 1, "Mark Steven Johnson", false, null, null, "PG-13", "When in Rome", "2010" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieID", "CategoryID", "director", "edited", "lentto", "notes", "rating", "title", "year" },
                values: new object[] { 3, 2, "Joe Johnston", false, null, null, "PG-13", "Captain America: The First Avenger", "2011" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieID", "CategoryID", "director", "edited", "lentto", "notes", "rating", "title", "year" },
                values: new object[] { 2, 3, "Tom McGrath", false, null, null, "PG", "Megamind", "2010" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryID",
                table: "Responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
