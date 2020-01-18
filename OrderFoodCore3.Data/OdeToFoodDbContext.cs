using Microsoft.EntityFrameworkCore;
using OrderFoodCore.Core;

namespace OrderFoodCore3.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
