using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MovieDataBase.Models
{
    public static class EnumHelpers
    {
        public static string GetDisplayName(ContentRating value)
        {
            var member = typeof(ContentRating).GetMember(value.ToString()).FirstOrDefault();
            if (member == null) return value.ToString();
            var display = member.GetCustomAttribute<DisplayAttribute>();
            return display?.Name ?? value.ToString();
        }

        public static string? GetDisplayName(ContentRating? value)
        {
            if (!value.HasValue) return null;
            return GetDisplayName(value.Value);
        }
    }
}
