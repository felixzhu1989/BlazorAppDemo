using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Data;

/// <summary>
/// 此类创建可用于注册数据库服务的数据库上下文。
/// 该上下文还让我们拥有将访问数据库的控制器。
/// </summary>
public class PizzaStoreContext:DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<PizzaSpecial> Specials { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configuring a many-to-many special -> topping relationship that is friendly for serialization
        modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
        modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
        modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();
    }

}