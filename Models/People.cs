using System.ComponentModel.DataAnnotations;

namespace MovieDataBase.Models
{
    public class People
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [Display(Name = "Born")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Died")]
        public DateTime? DateOfDeath { get; set; }
        public string? Biography { get; set; }
        public List<PeopleRolesInMovies>? MovieRoles { get; set; }
    }
}
