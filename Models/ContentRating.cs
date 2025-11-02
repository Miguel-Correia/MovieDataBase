using System.ComponentModel.DataAnnotations;

namespace MovieDataBase.Models
{
    public enum ContentRating
    {
        [Display(Name = "Unrated")]
        Unrated,

        [Display(Name = "G")]
        G,

        [Display(Name = "PG")]
        PG,

        [Display(Name = "PG-13")]
        PG13,

        [Display(Name = "R")]
        R,

        [Display(Name = "NC-17")]
        NC17
    }
}
