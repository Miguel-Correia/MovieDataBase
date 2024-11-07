using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDataBase.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }

        [Display(Name ="Date Released")]
        public DateOnly? DateReleased { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public int? Runtime { get; set; }
        public string? ContentRating { get; set; }
        public int? CritiqueScore { get; set; }
        [Display(Name = "Genres")]
        public List<MovieGenres>? MovieGenres { get; set; }
        public List<MovieImages>? Images { get; set; }
    }
}
