using System.ComponentModel.DataAnnotations.Schema;
using MovieDataBase.Services;

namespace MovieDataBase.Models
{
    public class MovieImages
    {
        public int Id { get; set; }
        public string? imageUrl { get; set; }
        public int? MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies? Movie { get; set; }
        [NotMapped]
        public string? FullUrl { get; set; }
        
    }
}
