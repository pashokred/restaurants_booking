using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            Tables = new List<Table>();
            RestaurantsDishes = new List<RestaurantsDishes>();
        }
        
        public int Id { get; set; }
        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Restaurant name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The field must not be empty")]
        public string City { get; set; }
        [Display(Name = "Information about the restaurant")]
        public string? Info { get; set; }
        public virtual ICollection<RestaurantsDishes> RestaurantsDishes { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}