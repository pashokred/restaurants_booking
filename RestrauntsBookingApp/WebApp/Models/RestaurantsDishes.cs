namespace WebApp.Models
{
    public class RestaurantsDishes
    {
        public int RestaurantId { get; set; }
        public int DishId { get; set; }
        public int Id { get; set; }
        
        public virtual Restaurant Restaurant { get; set; }
        public virtual Dish Dish { get; set; }
    }
}