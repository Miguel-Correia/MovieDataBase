using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDataBase.Models
{
    public class MovieImages
    {
        public int Id { get; set; }
        public string? image { get; set; }
        public int? MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies? Movie { get; set; }
    }
}
