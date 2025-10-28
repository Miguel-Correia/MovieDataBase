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
