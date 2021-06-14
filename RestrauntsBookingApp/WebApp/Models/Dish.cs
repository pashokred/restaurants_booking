using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable enable
namespace WebApp.Models
{
    public class Dish
    {
        public Dish(string name, string ingredients)
        {
            Name = name;
            Ingredients = ingredients;
            RestaurantsDishes = new List<RestaurantsDishes>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Dish name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Set of ingredients")]
        public string Ingredients { get; set; }
        [Display(Name = "Information about the dish")]
        public string? Info { get; set; }
        public virtual ICollection<RestaurantsDishes> RestaurantsDishes { get; set; }
    }
}