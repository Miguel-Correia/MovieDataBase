﻿using System;
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

        public DbSet<MovieDataBase.Models.Movies> Movies { get; set; } = default!;
        public DbSet<MovieDataBase.Models.Genre> Genre { get; set; } = default!;
    }
}
