﻿namespace MovieDataBase.Models
{
    public class MovieGenres
    {
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
