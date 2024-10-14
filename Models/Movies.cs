using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDataBase.Models
{
    public class Movies
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }

        [Display(Name ="Date Released")]
        public DateOnly? DateReleased { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public int? Runtime { get; set; }
        public string? ContentRating { get; set; }
        public int? CritiqueScore { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }
    }
}
