namespace MovieDataBase.Models
{
    public class Movies
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public DateOnly? DateReleased { get; set; }
    }
}
