using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class SeedPeopleRolesAndMoviesWritersProducers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Biography", "DateOfBirth", "DateOfDeath", "Name" },
                values: new object[,]
                {
                    { 21, "British-American screenwriter and producer, brother of Christopher Nolan. Co-wrote The Dark Knight trilogy, Interstellar, and created Westworld.", new DateTime(1976, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jonathan Nolan" },
                    { 22, "American screenwriter, film director and comic book writer. Known for writing Blade trilogy and The Dark Knight trilogy.", new DateTime(1965, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "David Goyer" },
                    { 23, "American author known as the 'King of Horror'. Wrote the novella 'Rita Hayworth and Shawshank Redemption' which inspired the film.", new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stephen King" },
                    { 24, "Canadian-American actor, comedian, and writer. Co-wrote Superbad with Evan Goldberg based on their teenage experiences.", new DateTime(1982, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seth Rogen" },
                    { 25, "Canadian screenwriter and producer. Frequent collaborator with Seth Rogen on films like Superbad and Pineapple Express.", new DateTime(1982, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Evan Goldberg" },
                    { 26, "American screenwriter. Academy Award winner for Forrest Gump. Also wrote Munich, The Curious Case of Benjamin Button, and Dune.", new DateTime(1945, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eric Roth" },
                    { 27, "American novelist and non-fiction writer. Wrote the novel 'Forrest Gump' which was adapted into the Oscar-winning film.", new DateTime(1943, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winston Groom" },
                    { 28, "British artist and designer. Co-wrote Mad Max: Fury Road and designed much of its distinctive visual style.", new DateTime(1957, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brendan McCarthy" },
                    { 29, "South Korean screenwriter. Co-wrote Parasite with Bong Joon-ho, winning the Academy Award for Best Original Screenplay.", new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Han Jin-won" },
                    { 30, "British film producer and wife of Christopher Nolan. Produced all of Nolan's films including The Dark Knight trilogy, Inception, and Interstellar.", new DateTime(1971, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Emma Thomas" },
                    { 31, "American film producer. Produced The Dark Knight trilogy, Man of Steel, and numerous other blockbusters.", new DateTime(1949, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Charles Roven" },
                    { 32, "American film producer. Worked on The Shawshank Redemption and The Majestic with Frank Darabont.", new DateTime(1952, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Niki Marvin" },
                    { 33, "American producer, director, and comedian. Produced Superbad and numerous other comedy hits like Knocked Up and The 40-Year-Old Virgin.", new DateTime(1967, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Judd Apatow" },
                    { 34, "American film producer. Produced Superbad and other Judd Apatow productions.", new DateTime(1968, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Shaun McKittrick" },
                    { 35, "American film producer. Won Academy Award for producing Forrest Gump. Also produced The Devil Wears Prada.", new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Wendy Finerman" },
                    { 36, "American film producer and businessman. Co-produced Forrest Gump. Also co-owner of the New York Giants NFL team.", new DateTime(1949, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Steve Tisch" },
                    { 37, "Australian film producer. Long-time collaborator with George Miller on Mad Max films and Babe.", new DateTime(1952, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doug Mitchell" },
                    { 38, "American film producer. Produced Interstellar, Contact, and Sleepless in Seattle.", new DateTime(1950, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lynda Obst" },
                    { 39, "South Korean film producer. Produced Parasite and The Handmaiden. President of Barunson E&A.", new DateTime(1968, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kwak Sin-ae" },
                    { 40, "South Korean film producer. Co-produced Parasite with Kwak Sin-ae.", new DateTime(1975, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jang Young-hwan" }
                });

            migrationBuilder.InsertData(
                table: "PeopleRolesInMovies",
                columns: new[] { "MovieId", "PeopleId", "RoleId", "CharacterName" },
                values: new object[,]
                {
                    { 2, 2, 3, null },
                    { 4, 1, 3, null },
                    { 6, 5, 3, null },
                    { 7, 1, 3, null },
                    { 8, 6, 3, null },
                    { 1, 21, 3, null },
                    { 1, 22, 3, null },
                    { 1, 30, 4, null },
                    { 1, 31, 4, null },
                    { 2, 23, 3, null },
                    { 2, 32, 4, null },
                    { 3, 24, 3, null },
                    { 3, 25, 3, null },
                    { 3, 33, 4, null },
                    { 3, 34, 4, null },
                    { 4, 30, 4, null },
                    { 5, 26, 3, null },
                    { 5, 27, 3, null },
                    { 5, 35, 4, null },
                    { 5, 36, 4, null },
                    { 6, 28, 3, null },
                    { 6, 37, 4, null },
                    { 7, 21, 3, null },
                    { 7, 30, 4, null },
                    { 7, 38, 4, null },
                    { 8, 29, 3, null },
                    { 8, 39, 4, null },
                    { 8, 40, 4, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 21, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 22, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 30, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 31, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 2, 2, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 2, 23, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 2, 32, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 3, 24, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 3, 25, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 3, 33, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 3, 34, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 4, 1, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 4, 30, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 5, 26, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 5, 27, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 5, 35, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 5, 36, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 6, 5, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 6, 28, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 6, 37, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 7, 1, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 7, 21, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 7, 30, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 7, 38, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 8, 6, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 8, 29, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 8, 39, 4 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 8, 40, 4 });

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 40);
        }
    }
}
