namespace BlazorECommerce.Server.Data;

public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    //种子数据
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id=1,
                    Title = "《三国演义》",
                    Description = "《三国演义》是元末明初小说家罗贯中根据陈寿《三国志》和裴松之注解以及民间三国故事传说经过艺术加工创作而成的长篇章回体历史演义小说。",
                    ImageUrl = "https://img.zcool.cn/community/01848c6031ccc011013ef90f6b3643.png@2o.png",
                    Price = 9.99m
                },
                new Product
                {
                    Id=2,
                    Title = "《西游记》",
                    Description = "《西游记》是明代吴承恩创作的中国古代第一部浪漫主义章回体长篇神魔小说。",
                    ImageUrl = "https://img.zcool.cn/community/01c56d6031ccc011013f3745e2d03d.png@1280w_1l_2o_100sh.png",
                    Price = 7.99m
                },
                new Product
                {
                    Id=3,
                    Title = "《水浒传》",
                    Description = "《水浒传》是元末明初施耐庵（现存刊本署名大多有施耐庵、罗贯中两人中的一人，或两人皆有）编著的章回体长篇小说。",
                    ImageUrl = "https://img.zcool.cn/community/0100bc6031ccc111013ef90f03d56c.png@2o.png",
                    Price = 6.99m
                }
            );
    }
}