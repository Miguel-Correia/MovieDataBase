﻿namespace MovieDataBase.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Movies>? Movies { get; set; }
    }
}
