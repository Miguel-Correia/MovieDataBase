using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class SeedPeopleRolesAndMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Biography", "DateOfBirth", "DateOfDeath", "Name" },
                values: new object[,]
                {
                    { 1, "British-American filmmaker known for his cerebral, often nonlinear storytelling. Notable works include The Dark Knight trilogy, Inception, and Interstellar.", new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Christopher Nolan" },
                    { 2, "American film director and screenwriter best known for his adaptations of Stephen King novels, including The Shawshank Redemption and The Green Mile.", new DateTime(1959, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Frank Darabont" },
                    { 3, "American filmmaker known for comedy films such as Superbad and Adventureland.", new DateTime(1964, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Greg Mottola" },
                    { 4, "American filmmaker known for Forrest Gump, Back to the Future trilogy, and pioneering motion-capture animation.", new DateTime(1951, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert Zemeckis" },
                    { 5, "Australian filmmaker best known for creating the Mad Max franchise and directing Happy Feet.", new DateTime(1945, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "George Miller" },
                    { 6, "South Korean filmmaker known for Parasite (winner of 4 Oscars including Best Picture), Snowpiercer, and Memories of Murder.", new DateTime(1969, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bong Joon-ho" },
                    { 7, "British actor known for his versatility and intense method acting. Famous for Batman trilogy, American Psycho, and The Machinist.", new DateTime(1974, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Christian Bale" },
                    { 8, "Australian actor who won a posthumous Oscar for his iconic portrayal of the Joker in The Dark Knight.", new DateTime(1979, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heath Ledger" },
                    { 9, "Legendary American actor and narrator with a distinctive voice. Academy Award winner known for roles in Shawshank Redemption and Million Dollar Baby.", new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Morgan Freeman" },
                    { 10, "American actor, screenwriter, and director known for The Shawshank Redemption and Mystic River.", new DateTime(1958, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tim Robbins" },
                    { 11, "American actor, comedian, and filmmaker. Two-time Oscar nominee known for Superbad, Moneyball, and The Wolf of Wall Street.", new DateTime(1983, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jonah Hill" },
                    { 12, "Canadian actor known for his awkward, comedic roles in Superbad, Juno, and Scott Pilgrim vs. the World.", new DateTime(1988, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Michael Cera" },
                    { 13, "Oscar-winning American actor and environmental activist. Known for Titanic, Inception, The Revenant, and collaborations with Scorsese.", new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Leonardo DiCaprio" },
                    { 14, "British actor known for intense physical transformations. Famous for Mad Max: Fury Road, The Dark Knight Rises, and Venom.", new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tom Hardy" },
                    { 15, "Canadian actor known for Juno, Inception, and The Umbrella Academy. Now known as Elliot Page.", new DateTime(1987, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ellen Page" },
                    { 16, "Two-time Oscar winner and one of Hollywood's most beloved actors. Known for Forrest Gump, Saving Private Ryan, and Cast Away.", new DateTime(1956, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tom Hanks" },
                    { 17, "South African-American actress and producer. Oscar winner known for Monster, Mad Max: Fury Road, and Atomic Blonde.", new DateTime(1975, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Charlize Theron" },
                    { 18, "Oscar-winning American actor known for Dallas Buyers Club, Interstellar, and True Detective.", new DateTime(1969, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Matthew McConaughey" },
                    { 19, "Oscar-winning American actress known for The Devil Wears Prada, Les Misérables, and Interstellar.", new DateTime(1982, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Anne Hathaway" },
                    { 20, "South Korean actor and Bong Joon-ho's frequent collaborator. Known for Parasite, Memories of Murder, and The Host.", new DateTime(1967, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Song Kang-ho" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Director" },
                    { 2, "Actor" },
                    { 3, "Writer" },
                    { 4, "Producer" }
                });

            migrationBuilder.InsertData(
                table: "PeopleRolesInMovies",
                columns: new[] { "MovieId", "PeopleId", "RoleId", "CharacterName" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 1, 7, 2, "Bruce Wayne / Batman" },
                    { 1, 8, 2, "The Joker" },
                    { 1, 9, 2, "Lucius Fox" },
                    { 2, 2, 1, null },
                    { 2, 9, 2, "Ellis Boyd 'Red' Redding" },
                    { 2, 10, 2, "Andy Dufresne" },
                    { 3, 3, 1, null },
                    { 3, 11, 2, "Seth" },
                    { 3, 12, 2, "Evan" },
                    { 4, 1, 1, null },
                    { 4, 13, 2, "Dom Cobb" },
                    { 4, 14, 2, "Eames" },
                    { 4, 15, 2, "Ariadne" },
                    { 5, 4, 1, null },
                    { 5, 16, 2, "Forrest Gump" },
                    { 6, 5, 1, null },
                    { 6, 14, 2, "Max Rockatansky" },
                    { 6, 17, 2, "Imperator Furiosa" },
                    { 7, 1, 1, null },
                    { 7, 18, 2, "Cooper" },
                    { 7, 19, 2, "Brand" },
                    { 8, 6, 1, null },
                    { 8, 20, 2, "Kim Ki-taek" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 7, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 8, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 1, 9, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 2, 2, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 2, 9, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 2, 10, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 3, 3, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 3, 11, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 3, 12, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 4, 1, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 4, 13, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 4, 14, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 4, 15, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 5, 4, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 5, 16, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 6, 5, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 6, 14, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 6, 17, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 7, 1, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 7, 18, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 7, 19, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 8, 6, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleRolesInMovies",
                keyColumns: new[] { "MovieId", "PeopleId", "RoleId" },
                keyValues: new object[] { 8, 20, 2 });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
