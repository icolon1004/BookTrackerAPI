using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleBooksId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartedReadingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedReadingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AddedAt", "Author", "CoverImageUrl", "Description", "FinishedReadingDate", "Genres", "GoogleBooksId", "ISBN", "PageCount", "PersonalNotes", "PublishedDate", "Rating", "Review", "StartedReadingDate", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 31, 14, 8, 13, 509, DateTimeKind.Local).AddTicks(2128), "J.R.R. Tolkien", null, "A fantasy adventure about Bilbo Baggins", new DateTime(2026, 1, 5, 14, 8, 13, 509, DateTimeKind.Local).AddTicks(2181), "Fantasy,Adventure", "sample1", null, 310, null, null, 5, "An absolute classic!", null, 2, "The Hobbit", new DateTime(2026, 1, 5, 14, 8, 13, 509, DateTimeKind.Local).AddTicks(2179) },
                    { 2, new DateTime(2026, 1, 25, 14, 8, 13, 509, DateTimeKind.Local).AddTicks(2190), "George Orwell", null, "A dystopian social science fiction novel", null, "Science Fiction,Dystopian", "sample2", null, 328, null, null, null, null, new DateTime(2026, 1, 30, 14, 8, 13, 509, DateTimeKind.Local).AddTicks(2194), 1, "1984", new DateTime(2026, 1, 30, 14, 8, 13, 509, DateTimeKind.Local).AddTicks(2192) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
