using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDataBase.Models
{
    public class MovieImages
    {
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
        public string? FileExtension { get; set; }
        public decimal Size { get; set; }
        public int? MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies? Movie { get; set; }
    }
}
