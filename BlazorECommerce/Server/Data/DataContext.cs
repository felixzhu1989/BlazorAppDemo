namespace BlazorECommerce.Server.Data;

public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    //种子数据
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductVariant>().HasKey(x => new { x.ProductId,x.ProductTypeId });//复合主键
        modelBuilder.Entity<CartItem>().HasKey(x => new {x.UserId, x.ProductId, x.ProductTypeId });//复合主键

        modelBuilder.Entity<ProductType>().HasData(
            new ProductType { Id=1,Name = "Default" },
            new ProductType { Id=2,Name = "Paperback" },
            new ProductType { Id=3,Name = "E-Book" },
            new ProductType { Id=4,Name = "Audiobook" },
            new ProductType { Id=5,Name = "Stream" },
            new ProductType { Id=6,Name = "Blu-ray" },
            new ProductType { Id=7,Name = "VHS" },
            new ProductType { Id=8,Name = "PC" },
            new ProductType { Id=9,Name = "PlayStation" },
            new ProductType { Id=10,Name = "Xbox" }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Books",
                Url="books"
            },
            new Category
            {
                Id = 2,
                Name = "Movies",
                Url="movies"
            },
            new Category
            {
                Id = 3,
                Name = "Video Games",
                Url="video-games"
            });


        modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id=1,
                    Title = "《三国演义》",
                    Description = "《三国演义》是元末明初小说家罗贯中根据陈寿《三国志》和裴松之注解以及民间三国故事传说经过艺术加工创作而成的长篇章回体历史演义小说。",
                    ImageUrl = "https://img.zcool.cn/community/01848c6031ccc011013ef90f6b3643.png@2o.png",
                    //Price = 9.99m,
                    CategoryId = 1,
                    Featured = true
                },
                new Product
                {
                    Id=2,
                    Title = "《西游记》",
                    Description = "《西游记》是明代吴承恩创作的中国古代第一部浪漫主义章回体长篇神魔小说。",
                    ImageUrl = "https://img.zcool.cn/community/01c56d6031ccc011013f3745e2d03d.png@1280w_1l_2o_100sh.png",
                    //Price = 7.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id=3,
                    Title = "《水浒传》",
                    Description = "《水浒传》是元末明初施耐庵（现存刊本署名大多有施耐庵、罗贯中两人中的一人，或两人皆有）编著的章回体长篇小说。",
                    ImageUrl = "https://img.zcool.cn/community/0100bc6031ccc111013ef90f03d56c.png@2o.png",
                    //Price = 6.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id=4,
                    Title = "《肖申克的救赎》",
                    Description = "《肖申克的救赎》The Shawshank Redemption 1994年这部被称为《刺激1995》的影片在中国影迷间也有极好的口碑，可见电影超越国界的神奇之处。",
                    ImageUrl = "http://img.szjqz.net/image/movie/7718045224070cb7fa4bcae2c85467c9.jpg",
                    //Price = 6.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id=5,
                    Title = "《教父》",
                    Description = "《教父》The Godfather 1972年科波拉黑帮经典《教父》的首部，派拉蒙公司最成功的影片之一，坐稳IMDB头把交椅应属众望所归。",
                    ImageUrl = "https://pic4.zhimg.com/v2-9db4ffdf47e979da4dd812ea09840162_qhd.jpg",
                    //Price = 6.99m,
                    CategoryId = 2,
                    Featured = true
                },
                new Product
                {
                    Id=6,
                    Title = "《辛德勒的名单》",
                    Description = "《辛德勒的名单》Schindler's List 1993年斯皮尔伯格在《大白鲨》、《夺宝奇兵》、《外星人》、《紫色》四次与奥斯卡失之交臂后，终于在辛德勒和无数犹太难民的帮助下捧得金像。",
                    ImageUrl = "https://pic.baike.soso.com/p/20120928/20120928185404-62640921.jpg",
                    //Price = 6.99m,
                    CategoryId = 2
                }, new Product
                {
                    Id=7,
                    Title = "《荒野大镖客》",
                    Description = "《荒野大镖客：救赎2》是一款由《GTA5》、《荒野大镖客：救赎》团队打造开发的第三人称射击游戏。",
                    ImageUrl = "https://game.cdn.betophall.com/ckfinder/userfiles/images/video/20190925/D3.jpg",
                    //Price = 6.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id=8,
                    Title = "《真三国无双》",
                    Description = "《真三国无双7》登场武将均来自古代中国大陆魏、吴、蜀三个国家。魏晋重要人物也会登场，这不禁让人感慨故事将会是多么的复杂纠结。",
                    ImageUrl = "https://img.3dmgame.com/uploads/images/news/20181127/1543287200_943463.jpg",
                    //Price = 6.99m,
                    CategoryId = 3,
                    Featured = true
                },
                new Product
                {
                    Id=9,
                    Title = "《使命召唤》",
                    Description = "《使命召唤：战区2》是一款多人竞技类第一人称射击游戏，是《使命召唤：战区》的全新续作。",
                    ImageUrl = "https://img.zcool.cn/community/0110f25747ee2c6ac72525ae4da6f7.jpg@1280w_1l_2o_100sh.jpg",
                    //Price = 6.99m,
                    CategoryId = 3
                }
            );
        //商品变体
        modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 2,
                    Price = 9.99m,
                    OriginalPrice = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 3,
                    Price = 7.99m
                },
                new ProductVariant
                {
                    ProductId = 1,
                    ProductTypeId = 4,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    ProductTypeId = 2,
                    Price = 7.99m,
                    OriginalPrice = 14.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    Price = 6.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 5,
                    Price = 3.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 6,
                    Price = 9.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    ProductTypeId = 7,
                    Price = 19.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    ProductTypeId = 5,
                    Price = 3.99m,
                },
                new ProductVariant
                {
                    ProductId = 6,
                    ProductTypeId = 5,
                    Price = 2.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 8,
                    Price = 19.99m,
                    OriginalPrice = 29.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 9,
                    Price = 69.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    ProductTypeId = 10,
                    Price = 49.99m,
                    OriginalPrice = 59.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    ProductTypeId = 8,
                    Price = 9.99m,
                    OriginalPrice = 24.99m,
                },
                new ProductVariant
                {
                    ProductId = 9,
                    ProductTypeId = 8,
                    Price = 14.99m
                }
            );
    }
}