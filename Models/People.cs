using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDataBase.Models
{
    public class People
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [Display(Name = "Born")]
        public DateOnly DateOfBirth { get; set; }
        [Display(Name = "Died")]
        public DateOnly? DateOfDeath { get; set; }
        public string? Biography { get; set; }
        public List<PeopleRolesInMovies>? MovieRoles { get; set; }
        public List<MovieImages>? Images { get; set; }
        
        [NotMapped]
        public IFormFileCollection? Files { get; set; }
    }
}
