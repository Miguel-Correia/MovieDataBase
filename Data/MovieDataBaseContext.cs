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
