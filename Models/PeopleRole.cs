namespace MovieDataBase.Models
{
    public class PeopleRole
    {
        public int PeopleId { get; set; }
        public People People { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
