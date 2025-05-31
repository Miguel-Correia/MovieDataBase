namespace MovieDataBase.Models
{
    public class PeopleRolesInMovies
    {
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
