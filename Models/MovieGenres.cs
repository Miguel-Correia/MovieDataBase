using System.ComponentModel.DataAnnotations;

namespace MovieDataBase.Models
{
    public class MovieGenres
    {
        public int MovieId { get; set; }
        [Required]
        public required Movies Movie { get; set; }
        public int GenreId { get; set; }
        public required Genre Genre { get; set; }
    }
}
