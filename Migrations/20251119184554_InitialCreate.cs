using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    director = table.Column<string>(type: "text", nullable: true),
                    date_released = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    runtime = table.Column<int>(type: "integer", nullable: true),
                    content_rating = table.Column<string>(type: "text", nullable: true),
                    critique_score = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    date_of_death = table.Column<DateOnly>(type: "date", nullable: true),
                    biography = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "movie_genres",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movie_genres", x => new { x.movie_id, x.genre_id });
                    table.ForeignKey(
                        name: "fk_movie_genres_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movie_genres_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movie_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    movie_id = table.Column<int>(type: "integer", nullable: true),
                    people_id = table.Column<int>(type: "integer", nullable: true),
                    is_poster = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movie_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_movie_images_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_movie_images_people_people_id",
                        column: x => x.people_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "people_roles_in_movies",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    people_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    character_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people_roles_in_movies", x => new { x.movie_id, x.people_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_people_roles_in_movies_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_people_roles_in_movies_people_people_id",
                        column: x => x.people_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_people_roles_in_movies_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "genre",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Fast-paced, high energy films.", "Action" },
                    { 2, "Emotion-driven storytelling.", "Drama" },
                    { 3, "Humorous and light-hearted films.", "Comedy" },
                    { 4, "Futuristic and science-based stories.", "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "id", "content_rating", "critique_score", "date_released", "description", "director", "runtime", "title" },
                values: new object[,]
                {
                    { 1, "PG13", 94, new DateOnly(2008, 7, 18), "Batman faces the Joker, a criminal mastermind who wants to plunge Gotham City into anarchy.", "Christopher Nolan", 152, "The Dark Knight" },
                    { 2, "R", 91, new DateOnly(1994, 9, 23), "Two imprisoned men bond over years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", 142, "The Shawshank Redemption" },
                    { 3, "R", 88, new DateOnly(2007, 8, 17), "Two co-dependent high school seniors are forced to deal with separation anxiety after their plan to stage a booze-soaked party goes awry.", "Greg Mottola", 113, "Superbad" },
                    { 4, "PG13", 87, new DateOnly(2010, 7, 16), "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea.", "Christopher Nolan", 148, "Inception" },
                    { 5, "PG13", 71, new DateOnly(1994, 7, 6), "The presidencies of Kennedy and Johnson, the Vietnam War, and other historical events unfold from the perspective of an Alabama man.", "Robert Zemeckis", 142, "Forrest Gump" },
                    { 6, "R", 97, new DateOnly(2015, 5, 15), "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search for her homeland with the aid of a group of female prisoners.", "George Miller", 120, "Mad Max: Fury Road" },
                    { 7, "PG13", 72, new DateOnly(2014, 11, 7), "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", "Christopher Nolan", 169, "Interstellar" },
                    { 8, "R", 96, new DateOnly(2019, 5, 30), "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", "Bong Joon-ho", 132, "Parasite" }
                });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "id", "biography", "date_of_birth", "date_of_death", "name" },
                values: new object[,]
                {
                    { 1, "British-American filmmaker known for his cerebral, often nonlinear storytelling. Notable works include The Dark Knight trilogy, Inception, and Interstellar.", new DateOnly(1970, 7, 30), null, "Christopher Nolan" },
                    { 2, "American film director and screenwriter best known for his adaptations of Stephen King novels, including The Shawshank Redemption and The Green Mile.", new DateOnly(1959, 1, 28), null, "Frank Darabont" },
                    { 3, "American filmmaker known for comedy films such as Superbad and Adventureland.", new DateOnly(1964, 7, 11), null, "Greg Mottola" },
                    { 4, "American filmmaker known for Forrest Gump, Back to the Future trilogy, and pioneering motion-capture animation.", new DateOnly(1951, 5, 14), null, "Robert Zemeckis" },
                    { 5, "Australian filmmaker best known for creating the Mad Max franchise and directing Happy Feet.", new DateOnly(1945, 3, 3), null, "George Miller" },
                    { 6, "South Korean filmmaker known for Parasite (winner of 4 Oscars including Best Picture), Snowpiercer, and Memories of Murder.", new DateOnly(1969, 9, 14), null, "Bong Joon-ho" },
                    { 7, "British actor known for his versatility and intense method acting. Famous for Batman trilogy, American Psycho, and The Machinist.", new DateOnly(1974, 1, 30), null, "Christian Bale" },
                    { 8, "Australian actor who won a posthumous Oscar for his iconic portrayal of the Joker in The Dark Knight.", new DateOnly(1979, 4, 4), new DateOnly(2008, 1, 22), "Heath Ledger" },
                    { 9, "Legendary American actor and narrator with a distinctive voice. Academy Award winner known for roles in Shawshank Redemption and Million Dollar Baby.", new DateOnly(1937, 6, 1), null, "Morgan Freeman" },
                    { 10, "American actor, screenwriter, and director known for The Shawshank Redemption and Mystic River.", new DateOnly(1958, 10, 16), null, "Tim Robbins" },
                    { 11, "American actor, comedian, and filmmaker. Two-time Oscar nominee known for Superbad, Moneyball, and The Wolf of Wall Street.", new DateOnly(1983, 12, 20), null, "Jonah Hill" },
                    { 12, "Canadian actor known for his awkward, comedic roles in Superbad, Juno, and Scott Pilgrim vs. the World.", new DateOnly(1988, 6, 7), null, "Michael Cera" },
                    { 13, "Oscar-winning American actor and environmental activist. Known for Titanic, Inception, The Revenant, and collaborations with Scorsese.", new DateOnly(1974, 11, 11), null, "Leonardo DiCaprio" },
                    { 14, "British actor known for intense physical transformations. Famous for Mad Max: Fury Road, The Dark Knight Rises, and Venom.", new DateOnly(1977, 9, 15), null, "Tom Hardy" },
                    { 15, "Canadian actor known for Juno, Inception, and The Umbrella Academy. Now known as Elliot Page.", new DateOnly(1987, 2, 21), null, "Ellen Page" },
                    { 16, "Two-time Oscar winner and one of Hollywood's most beloved actors. Known for Forrest Gump, Saving Private Ryan, and Cast Away.", new DateOnly(1956, 7, 9), null, "Tom Hanks" },
                    { 17, "South African-American actress and producer. Oscar winner known for Monster, Mad Max: Fury Road, and Atomic Blonde.", new DateOnly(1975, 8, 7), null, "Charlize Theron" },
                    { 18, "Oscar-winning American actor known for Dallas Buyers Club, Interstellar, and True Detective.", new DateOnly(1969, 11, 4), null, "Matthew McConaughey" },
                    { 19, "Oscar-winning American actress known for The Devil Wears Prada, Les Misérables, and Interstellar.", new DateOnly(1982, 11, 12), null, "Anne Hathaway" },
                    { 20, "South Korean actor and Bong Joon-ho's frequent collaborator. Known for Parasite, Memories of Murder, and The Host.", new DateOnly(1967, 1, 17), null, "Song Kang-ho" },
                    { 21, "British-American screenwriter and producer, brother of Christopher Nolan. Co-wrote The Dark Knight trilogy, Interstellar, and created Westworld.", new DateOnly(1976, 6, 6), null, "Jonathan Nolan" },
                    { 22, "American screenwriter, film director and comic book writer. Known for writing Blade trilogy and The Dark Knight trilogy.", new DateOnly(1965, 12, 22), null, "David Goyer" },
                    { 23, "American author known as the 'King of Horror'. Wrote the novella 'Rita Hayworth and Shawshank Redemption' which inspired the film.", new DateOnly(1947, 9, 21), null, "Stephen King" },
                    { 24, "Canadian-American actor, comedian, and writer. Co-wrote Superbad with Evan Goldberg based on their teenage experiences.", new DateOnly(1982, 4, 15), null, "Seth Rogen" },
                    { 25, "Canadian screenwriter and producer. Frequent collaborator with Seth Rogen on films like Superbad and Pineapple Express.", new DateOnly(1982, 9, 11), null, "Evan Goldberg" },
                    { 26, "American screenwriter. Academy Award winner for Forrest Gump. Also wrote Munich, The Curious Case of Benjamin Button, and Dune.", new DateOnly(1945, 3, 22), null, "Eric Roth" },
                    { 27, "American novelist and non-fiction writer. Wrote the novel 'Forrest Gump' which was adapted into the Oscar-winning film.", new DateOnly(1943, 3, 23), new DateOnly(2020, 9, 17), "Winston Groom" },
                    { 28, "British artist and designer. Co-wrote Mad Max: Fury Road and designed much of its distinctive visual style.", new DateOnly(1957, 3, 28), null, "Brendan McCarthy" },
                    { 29, "South Korean screenwriter. Co-wrote Parasite with Bong Joon-ho, winning the Academy Award for Best Original Screenplay.", new DateOnly(1989, 1, 1), null, "Han Jin-won" },
                    { 30, "British film producer and wife of Christopher Nolan. Produced all of Nolan's films including The Dark Knight trilogy, Inception, and Interstellar.", new DateOnly(1971, 12, 9), null, "Emma Thomas" },
                    { 31, "American film producer. Produced The Dark Knight trilogy, Man of Steel, and numerous other blockbusters.", new DateOnly(1949, 8, 2), null, "Charles Roven" },
                    { 32, "American film producer. Worked on The Shawshank Redemption and The Majestic with Frank Darabont.", new DateOnly(1952, 6, 8), null, "Niki Marvin" },
                    { 33, "American producer, director, and comedian. Produced Superbad and numerous other comedy hits like Knocked Up and The 40-Year-Old Virgin.", new DateOnly(1967, 12, 6), null, "Judd Apatow" },
                    { 34, "American film producer. Produced Superbad and other Judd Apatow productions.", new DateOnly(1968, 5, 15), null, "Shaun McKittrick" },
                    { 35, "American film producer. Won Academy Award for producing Forrest Gump. Also produced The Devil Wears Prada.", new DateOnly(1960, 1, 1), null, "Wendy Finerman" },
                    { 36, "American film producer and businessman. Co-produced Forrest Gump. Also co-owner of the New York Giants NFL team.", new DateOnly(1949, 2, 14), null, "Steve Tisch" },
                    { 37, "Australian film producer. Long-time collaborator with George Miller on Mad Max films and Babe.", new DateOnly(1952, 10, 15), null, "Doug Mitchell" },
                    { 38, "American film producer. Produced Interstellar, Contact, and Sleepless in Seattle.", new DateOnly(1950, 4, 14), null, "Lynda Obst" },
                    { 39, "South Korean film producer. Produced Parasite and The Handmaiden. President of Barunson E&A.", new DateOnly(1968, 3, 12), null, "Kwak Sin-ae" },
                    { 40, "South Korean film producer. Co-produced Parasite with Kwak Sin-ae.", new DateOnly(1975, 5, 20), null, "Jang Young-hwan" }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Director" },
                    { 2, "Actor" },
                    { 3, "Writer" },
                    { 4, "Producer" }
                });

            migrationBuilder.InsertData(
                table: "movie_genres",
                columns: new[] { "genre_id", "movie_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 4, 4 },
                    { 2, 5 },
                    { 3, 5 },
                    { 1, 6 },
                    { 4, 6 },
                    { 2, 7 },
                    { 4, 7 },
                    { 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "people_roles_in_movies",
                columns: new[] { "movie_id", "people_id", "role_id", "character_name" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 1, 7, 2, "Bruce Wayne / Batman" },
                    { 1, 8, 2, "The Joker" },
                    { 1, 9, 2, "Lucius Fox" },
                    { 1, 21, 3, null },
                    { 1, 22, 3, null },
                    { 1, 30, 4, null },
                    { 1, 31, 4, null },
                    { 2, 2, 1, null },
                    { 2, 2, 3, null },
                    { 2, 9, 2, "Ellis Boyd 'Red' Redding" },
                    { 2, 10, 2, "Andy Dufresne" },
                    { 2, 23, 3, null },
                    { 2, 32, 4, null },
                    { 3, 3, 1, null },
                    { 3, 11, 2, "Seth" },
                    { 3, 12, 2, "Evan" },
                    { 3, 24, 3, null },
                    { 3, 25, 3, null },
                    { 3, 33, 4, null },
                    { 3, 34, 4, null },
                    { 4, 1, 1, null },
                    { 4, 1, 3, null },
                    { 4, 13, 2, "Dom Cobb" },
                    { 4, 14, 2, "Eames" },
                    { 4, 15, 2, "Ariadne" },
                    { 4, 30, 4, null },
                    { 5, 4, 1, null },
                    { 5, 16, 2, "Forrest Gump" },
                    { 5, 26, 3, null },
                    { 5, 27, 3, null },
                    { 5, 35, 4, null },
                    { 5, 36, 4, null },
                    { 6, 5, 1, null },
                    { 6, 5, 3, null },
                    { 6, 14, 2, "Max Rockatansky" },
                    { 6, 17, 2, "Imperator Furiosa" },
                    { 6, 28, 3, null },
                    { 6, 37, 4, null },
                    { 7, 1, 1, null },
                    { 7, 1, 3, null },
                    { 7, 18, 2, "Cooper" },
                    { 7, 19, 2, "Brand" },
                    { 7, 21, 3, null },
                    { 7, 30, 4, null },
                    { 7, 38, 4, null },
                    { 8, 6, 1, null },
                    { 8, 6, 3, null },
                    { 8, 20, 2, "Kim Ki-taek" },
                    { 8, 29, 3, null },
                    { 8, 39, 4, null },
                    { 8, 40, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_movie_genres_genre_id",
                table: "movie_genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "ix_movie_images_movie_id",
                table: "movie_images",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "ix_movie_images_people_id",
                table: "movie_images",
                column: "people_id");

            migrationBuilder.CreateIndex(
                name: "ix_people_roles_in_movies_people_id",
                table: "people_roles_in_movies",
                column: "people_id");

            migrationBuilder.CreateIndex(
                name: "ix_people_roles_in_movies_role_id",
                table: "people_roles_in_movies",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movie_genres");

            migrationBuilder.DropTable(
                name: "movie_images");

            migrationBuilder.DropTable(
                name: "people_roles_in_movies");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
