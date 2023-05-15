using Microsoft.EntityFrameworkCore;

namespace MVCSecond.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }
        public DbSet<MVCSecond.Models.Pizza>? Pizzas { get; set; }
    }
}