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
                new Movies { Id = 1, Title = "Edge of Dawn", Director = "A. Silva", DateReleased = new DateOnly(2020, 5, 1), Description = "High-octane action thriller.", Runtime = 118, ContentRating = "PG-13", CritiqueScore = 78 },
                new Movies { Id = 2, Title = "Silent River", Director = "M. Costa", DateReleased = new DateOnly(2019, 10, 12), Description = "Emotional drama about family and loss.", Runtime = 105, ContentRating = "R", CritiqueScore = 84 },
                new Movies { Id = 3, Title = "Laugh Riot", Director = "R. Pereira", DateReleased = new DateOnly(2021, 3, 20), Description = "Light-hearted comedy for all ages.", Runtime = 95, ContentRating = "PG", CritiqueScore = 70 },
                new Movies { Id = 4, Title = "Neon Galaxy", Director = "L. Fernandes", DateReleased = new DateOnly(2022, 8, 5), Description = "Visually stunning sci-fi adventure.", Runtime = 132, ContentRating = "PG-13", CritiqueScore = 88 },
                new Movies { Id = 5, Title = "Crossroads", Director = "S. Almeida", DateReleased = new DateOnly(2018, 11, 2), Description = "Drama with surprising twists.", Runtime = 110, ContentRating = "PG-13", CritiqueScore = 76 }
            );
        
            // --- SEED MOVIE-GENRE RELATIONS ---
            modelBuilder.Entity<MovieGenres>().HasData(
                new { MovieId = 1, GenreId = 1 },
                new { MovieId = 2, GenreId = 2 },
                new { MovieId = 3, GenreId = 3 },
                new { MovieId = 4, GenreId = 4 },
                new { MovieId = 5, GenreId = 2 }
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
