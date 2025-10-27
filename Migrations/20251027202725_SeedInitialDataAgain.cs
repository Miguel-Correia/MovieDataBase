using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDataAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Fast-paced, high energy films.", "Action" },
                    { 2, "Emotion-driven storytelling.", "Drama" },
                    { 3, "Humorous and light-hearted films.", "Comedy" },
                    { 4, "Futuristic and science-based stories.", "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ContentRating", "CritiqueScore", "DateReleased", "Description", "Director", "Runtime", "Title" },
                values: new object[,]
                {
                    { 1, "PG-13", 78, new DateOnly(2020, 5, 1), "High-octane action thriller.", "A. Silva", 118, "Edge of Dawn" },
                    { 2, "R", 84, new DateOnly(2019, 10, 12), "Emotional drama about family and loss.", "M. Costa", 105, "Silent River" },
                    { 3, "PG", 70, new DateOnly(2021, 3, 20), "Light-hearted comedy for all ages.", "R. Pereira", 95, "Laugh Riot" },
                    { 4, "PG-13", 88, new DateOnly(2022, 8, 5), "Visually stunning sci-fi adventure.", "L. Fernandes", 132, "Neon Galaxy" },
                    { 5, "PG-13", 76, new DateOnly(2018, 11, 2), "Drama with surprising twists.", "S. Almeida", 110, "Crossroads" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 2, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
