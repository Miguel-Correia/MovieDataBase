using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieDataBase.Models;

namespace MovieDataBase.Data
{
    public class MovieDataBaseContext : DbContext
    {
        public MovieDataBaseContext (DbContextOptions<MovieDataBaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenres>().HasKey(mg => new
            {
                mg.MovieId,
                mg.GenreId
            });

            modelBuilder.Entity<MovieGenres>().HasOne(mg => mg.Movie).WithMany(mg => mg.MovieGenres).HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenres>().HasOne(mg => mg.Genre).WithMany(mg => mg.MovieGenres).HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<MovieImages>().HasOne(mi => mi.Movie).WithMany(m => m.Images).HasForeignKey(mi => mi.MovieId);

            modelBuilder.Entity<PeopleRolesInMovies>().HasKey(pr => new
            {
                pr.MovieId,
                pr.PeopleId,
                pr.RoleId
            });

            modelBuilder.Entity<PeopleRolesInMovies>().HasOne(pr => pr.People).WithMany(p => p.MovieRoles).HasForeignKey(mg => mg.PeopleId);
            modelBuilder.Entity<PeopleRolesInMovies>().HasOne(pr => pr.Role).WithMany(r => r.PeopleInMovies).HasForeignKey(mg => mg.RoleId);
            modelBuilder.Entity<PeopleRolesInMovies>().HasOne(pr => pr.Movie).WithMany(m => m.PeopleRoles).HasForeignKey(mg => mg.MovieId);

            // --- SEED GENRES ---
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action", Description = "Fast-paced, high energy films." },
                new Genre { Id = 2, Name = "Drama", Description = "Emotion-driven storytelling." },
                new Genre { Id = 3, Name = "Comedy", Description = "Humorous and light-hearted films." },
                new Genre { Id = 4, Name = "Sci-Fi", Description = "Futuristic and science-based stories." }
            );
            
            // --- SEED MOVIES ---
            modelBuilder.Entity<Movies>().HasData(
                new Movies 
                { 
                    Id = 1, 
                    Title = "The Dark Knight", 
                    Director = "Christopher Nolan", 
                    DateReleased = new DateOnly(2008, 7, 18), 
                    Description = "Batman faces the Joker, a criminal mastermind who wants to plunge Gotham City into anarchy.", 
                    Runtime = 152, 
                    ContentRating = "PG-13", 
                    CritiqueScore = 94 
                },
                new Movies 
                { 
                    Id = 2, 
                    Title = "The Shawshank Redemption", 
                    Director = "Frank Darabont", 
                    DateReleased = new DateOnly(1994, 9, 23), 
                    Description = "Two imprisoned men bond over years, finding solace and eventual redemption through acts of common decency.", 
                    Runtime = 142, 
                    ContentRating = "R", 
                    CritiqueScore = 91 
                },
                new Movies 
                { 
                    Id = 3, 
                    Title = "Superbad", 
                    Director = "Greg Mottola", 
                    DateReleased = new DateOnly(2007, 8, 17), 
                    Description = "Two co-dependent high school seniors are forced to deal with separation anxiety after their plan to stage a booze-soaked party goes awry.", 
                    Runtime = 113, 
                    ContentRating = "R", 
                    CritiqueScore = 88 
                },
                new Movies 
                { 
                    Id = 4, 
                    Title = "Inception", 
                    Director = "Christopher Nolan", 
                    DateReleased = new DateOnly(2010, 7, 16), 
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea.", 
                    Runtime = 148, 
                    ContentRating = "PG-13", 
                    CritiqueScore = 87 
                },
                new Movies 
                { 
                    Id = 5, 
                    Title = "Forrest Gump", 
                    Director = "Robert Zemeckis", 
                    DateReleased = new DateOnly(1994, 7, 6), 
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, and other historical events unfold from the perspective of an Alabama man.", 
                    Runtime = 142, 
                    ContentRating = "PG-13", 
                    CritiqueScore = 71 
                },
                new Movies 
                { 
                    Id = 6, 
                    Title = "Mad Max: Fury Road", 
                    Director = "George Miller", 
                    DateReleased = new DateOnly(2015, 5, 15), 
                    Description = "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search for her homeland with the aid of a group of female prisoners.", 
                    Runtime = 120, 
                    ContentRating = "R", 
                    CritiqueScore = 97 
                },
                new Movies 
                { 
                    Id = 7, 
                    Title = "Interstellar", 
                    Director = "Christopher Nolan", 
                    DateReleased = new DateOnly(2014, 11, 7), 
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", 
                    Runtime = 169, 
                    ContentRating = "PG-13", 
                    CritiqueScore = 72 
                },
                new Movies 
                { 
                    Id = 8, 
                    Title = "Parasite", 
                    Director = "Bong Joon-ho", 
                    DateReleased = new DateOnly(2019, 5, 30), 
                    Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", 
                    Runtime = 132, 
                    ContentRating = "R", 
                    CritiqueScore = 96 
                }
            );

            // --- SEED MOVIE-GENRE RELATIONS ---
            modelBuilder.Entity<MovieGenres>().HasData(
                // The Dark Knight - Action & Drama
                new { MovieId = 1, GenreId = 1 },
                new { MovieId = 1, GenreId = 2 },

                // The Shawshank Redemption - Drama
                new { MovieId = 2, GenreId = 2 },

                // Superbad - Comedy
                new { MovieId = 3, GenreId = 3 },

                // Inception - Sci-Fi & Action
                new { MovieId = 4, GenreId = 4 },
                new { MovieId = 4, GenreId = 1 },

                // Forrest Gump - Drama & Comedy
                new { MovieId = 5, GenreId = 2 },
                new { MovieId = 5, GenreId = 3 },

                // Mad Max: Fury Road - Action & Sci-Fi
                new { MovieId = 6, GenreId = 1 },
                new { MovieId = 6, GenreId = 4 },

                // Interstellar - Sci-Fi & Drama
                new { MovieId = 7, GenreId = 4 },
                new { MovieId = 7, GenreId = 2 },

                // Parasite - Drama
                new { MovieId = 8, GenreId = 2 }
            );

			// --- SEED PEOPLE ---
			modelBuilder.Entity<People>().HasData(
				// Diretores
				new People
				{
					Id = 1,
					Name = "Christopher Nolan",
					DateOfBirth = new DateTime(1970, 7, 30),
					Biography = "British-American filmmaker known for his cerebral, often nonlinear storytelling. Notable works include The Dark Knight trilogy, Inception, and Interstellar."
				},
				new People
				{
					Id = 2,
					Name = "Frank Darabont",
					DateOfBirth = new DateTime(1959, 1, 28),
					Biography = "American film director and screenwriter best known for his adaptations of Stephen King novels, including The Shawshank Redemption and The Green Mile."
				},
				new People
				{
					Id = 3,
					Name = "Greg Mottola",
					DateOfBirth = new DateTime(1964, 7, 11),
					Biography = "American filmmaker known for comedy films such as Superbad and Adventureland."
				},
				new People
				{
					Id = 4,
					Name = "Robert Zemeckis",
					DateOfBirth = new DateTime(1951, 5, 14),
					Biography = "American filmmaker known for Forrest Gump, Back to the Future trilogy, and pioneering motion-capture animation."
				},
				new People
				{
					Id = 5,
					Name = "George Miller",
					DateOfBirth = new DateTime(1945, 3, 3),
					Biography = "Australian filmmaker best known for creating the Mad Max franchise and directing Happy Feet."
				},
				new People
				{
					Id = 6,
					Name = "Bong Joon-ho",
					DateOfBirth = new DateTime(1969, 9, 14),
					Biography = "South Korean filmmaker known for Parasite (winner of 4 Oscars including Best Picture), Snowpiercer, and Memories of Murder."
				},

				// Atores - The Dark Knight
				new People
				{
					Id = 7,
					Name = "Christian Bale",
					DateOfBirth = new DateTime(1974, 1, 30),
					Biography = "British actor known for his versatility and intense method acting. Famous for Batman trilogy, American Psycho, and The Machinist."
				},
				new People
				{
					Id = 8,
					Name = "Heath Ledger",
					DateOfBirth = new DateTime(1979, 4, 4),
					DateOfDeath = new DateTime(2008, 1, 22),
					Biography = "Australian actor who won a posthumous Oscar for his iconic portrayal of the Joker in The Dark Knight."
				},
				new People
				{
					Id = 9,
					Name = "Morgan Freeman",
					DateOfBirth = new DateTime(1937, 6, 1),
					Biography = "Legendary American actor and narrator with a distinctive voice. Academy Award winner known for roles in Shawshank Redemption and Million Dollar Baby."
				},

				// Atores - Shawshank Redemption
				new People
				{
					Id = 10,
					Name = "Tim Robbins",
					DateOfBirth = new DateTime(1958, 10, 16),
					Biography = "American actor, screenwriter, and director known for The Shawshank Redemption and Mystic River."
				},

				// Atores - Superbad
				new People
				{
					Id = 11,
					Name = "Jonah Hill",
					DateOfBirth = new DateTime(1983, 12, 20),
					Biography = "American actor, comedian, and filmmaker. Two-time Oscar nominee known for Superbad, Moneyball, and The Wolf of Wall Street."
				},
				new People
				{
					Id = 12,
					Name = "Michael Cera",
					DateOfBirth = new DateTime(1988, 6, 7),
					Biography = "Canadian actor known for his awkward, comedic roles in Superbad, Juno, and Scott Pilgrim vs. the World."
				},

				// Atores - Inception
				new People
				{
					Id = 13,
					Name = "Leonardo DiCaprio",
					DateOfBirth = new DateTime(1974, 11, 11),
					Biography = "Oscar-winning American actor and environmental activist. Known for Titanic, Inception, The Revenant, and collaborations with Scorsese."
				},
				new People
				{
					Id = 14,
					Name = "Tom Hardy",
					DateOfBirth = new DateTime(1977, 9, 15),
					Biography = "British actor known for intense physical transformations. Famous for Mad Max: Fury Road, The Dark Knight Rises, and Venom."
				},
				new People
				{
					Id = 15,
					Name = "Ellen Page",
					DateOfBirth = new DateTime(1987, 2, 21),
					Biography = "Canadian actor known for Juno, Inception, and The Umbrella Academy. Now known as Elliot Page."
				},

				// Atores - Forrest Gump
				new People
				{
					Id = 16,
					Name = "Tom Hanks",
					DateOfBirth = new DateTime(1956, 7, 9),
					Biography = "Two-time Oscar winner and one of Hollywood's most beloved actors. Known for Forrest Gump, Saving Private Ryan, and Cast Away."
				},

				// Atores - Mad Max: Fury Road
				new People
				{
					Id = 17,
					Name = "Charlize Theron",
					DateOfBirth = new DateTime(1975, 8, 7),
					Biography = "South African-American actress and producer. Oscar winner known for Monster, Mad Max: Fury Road, and Atomic Blonde."
				},

				// Atores - Interstellar
				new People
				{
					Id = 18,
					Name = "Matthew McConaughey",
					DateOfBirth = new DateTime(1969, 11, 4),
					Biography = "Oscar-winning American actor known for Dallas Buyers Club, Interstellar, and True Detective."
				},
				new People
				{
					Id = 19,
					Name = "Anne Hathaway",
					DateOfBirth = new DateTime(1982, 11, 12),
					Biography = "Oscar-winning American actress known for The Devil Wears Prada, Les Misérables, and Interstellar."
				},

				// Atores - Parasite
				new People
				{
					Id = 20,
					Name = "Song Kang-ho",
					DateOfBirth = new DateTime(1967, 1, 17),
					Biography = "South Korean actor and Bong Joon-ho's frequent collaborator. Known for Parasite, Memories of Murder, and The Host."
				}
			);

			// --- SEED ROLES ---
			modelBuilder.Entity<Role>().HasData(
				new Role { Id = 1, Name = "Director" },
				new Role { Id = 2, Name = "Actor" },
				new Role { Id = 3, Name = "Writer" },
				new Role { Id = 4, Name = "Producer" }
			);
			
			// --- SEED PEOPLE-ROLES-IN-MOVIES (Tabela de Junção) ---
			modelBuilder.Entity<PeopleRolesInMovies>().HasData(
			    // The Dark Knight (MovieId: 1)
			    new { MovieId = 1, PeopleId = 1, RoleId = 1, CharacterName = (string?)null },  // Christopher Nolan - Director
			    new { MovieId = 1, PeopleId = 7, RoleId = 2, CharacterName = "Bruce Wayne / Batman" },  // Christian Bale - Actor
			    new { MovieId = 1, PeopleId = 8, RoleId = 2, CharacterName = "The Joker" },  // Heath Ledger - Actor
			    new { MovieId = 1, PeopleId = 9, RoleId = 2, CharacterName = "Lucius Fox" },  // Morgan Freeman - Actor
			
			    // The Shawshank Redemption (MovieId: 2)
			    new { MovieId = 2, PeopleId = 2, RoleId = 1, CharacterName = (string?)null },  // Frank Darabont - Director
			    new { MovieId = 2, PeopleId = 10, RoleId = 2, CharacterName = "Andy Dufresne" },  // Tim Robbins - Actor
			    new { MovieId = 2, PeopleId = 9, RoleId = 2, CharacterName = "Ellis Boyd 'Red' Redding" },  // Morgan Freeman - Actor
			
			    // Superbad (MovieId: 3)
			    new { MovieId = 3, PeopleId = 3, RoleId = 1, CharacterName = (string?)null },  // Greg Mottola - Director
			    new { MovieId = 3, PeopleId = 11, RoleId = 2, CharacterName = "Seth" },  // Jonah Hill - Actor
			    new { MovieId = 3, PeopleId = 12, RoleId = 2, CharacterName = "Evan" },  // Michael Cera - Actor
			
			    // Inception (MovieId: 4)
			    new { MovieId = 4, PeopleId = 1, RoleId = 1, CharacterName = (string?)null },  // Christopher Nolan - Director
			    new { MovieId = 4, PeopleId = 13, RoleId = 2, CharacterName = "Dom Cobb" },  // Leonardo DiCaprio - Actor
			    new { MovieId = 4, PeopleId = 14, RoleId = 2, CharacterName = "Eames" },  // Tom Hardy - Actor
			    new { MovieId = 4, PeopleId = 15, RoleId = 2, CharacterName = "Ariadne" },  // Elliot Page - Actor
			
			    // Forrest Gump (MovieId: 5)
			    new { MovieId = 5, PeopleId = 4, RoleId = 1, CharacterName = (string?)null },  // Robert Zemeckis - Director
			    new { MovieId = 5, PeopleId = 16, RoleId = 2, CharacterName = "Forrest Gump" },  // Tom Hanks - Actor
			
			    // Mad Max: Fury Road (MovieId: 6)
			    new { MovieId = 6, PeopleId = 5, RoleId = 1, CharacterName = (string?)null },  // George Miller - Director
			    new { MovieId = 6, PeopleId = 14, RoleId = 2, CharacterName = "Max Rockatansky" },  // Tom Hardy - Actor
			    new { MovieId = 6, PeopleId = 17, RoleId = 2, CharacterName = "Imperator Furiosa" },  // Charlize Theron - Actor
			
			    // Interstellar (MovieId: 7)
			    new { MovieId = 7, PeopleId = 1, RoleId = 1, CharacterName = (string?)null },  // Christopher Nolan - Director
			    new { MovieId = 7, PeopleId = 18, RoleId = 2, CharacterName = "Cooper" },  // Matthew McConaughey - Actor
			    new { MovieId = 7, PeopleId = 19, RoleId = 2, CharacterName = "Brand" },  // Anne Hathaway - Actor
			
			    // Parasite (MovieId: 8)
			    new { MovieId = 8, PeopleId = 6, RoleId = 1, CharacterName = (string?)null },  // Bong Joon-ho - Director
			    new { MovieId = 8, PeopleId = 20, RoleId = 2, CharacterName = "Kim Ki-taek" }  // Song Kang-ho - Actor
			);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MovieDataBase.Models.Movies> Movies { get; set; } = default!;
        public DbSet<MovieDataBase.Models.Genre> Genre { get; set; } = default!;
        public DbSet<MovieGenres> MovieGenres { get; set; } = default!;
        public DbSet<MovieImages> MovieImages { get; set; }
        public DbSet<MovieDataBase.Models.People> People { get; set; } = default!;
        public DbSet<MovieDataBase.Models.Role> Role { get; set; } = default!;
        public DbSet<MovieDataBase.Models.PeopleRolesInMovies> PeopleRolesInMovies { get; set; } = default!;


    }
}
