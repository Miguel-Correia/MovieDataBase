namespace MovieDataBase.Models
{
    public class PeopleRolesInMovies
    {
        public int MovieId { get; set; }
        public required Movies Movie { get; set; }
        public int PeopleId { get; set; }
        public required People People { get; set; }
        public int RoleId { get; set; }
        public required Role Role { get; set; }
        public string? CharacterName { get; set; }
    }
}
