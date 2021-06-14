using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class RestaurantsContext : DbContext
    {
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantsDishes> RestaurantsDishes { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        public RestaurantsContext(DbContextOptions<RestaurantsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}