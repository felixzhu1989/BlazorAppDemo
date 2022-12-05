﻿// <auto-generated />
using System;
using BlazorECommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorECommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221204080237_addUser")]
    partial class addUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorECommerce.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Movies",
                            Url = "movies"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Video Games",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("BlazorECommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "《三国演义》是元末明初小说家罗贯中根据陈寿《三国志》和裴松之注解以及民间三国故事传说经过艺术加工创作而成的长篇章回体历史演义小说。",
                            Featured = true,
                            ImageUrl = "https://img.zcool.cn/community/01848c6031ccc011013ef90f6b3643.png@2o.png",
                            Title = "《三国演义》"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "《西游记》是明代吴承恩创作的中国古代第一部浪漫主义章回体长篇神魔小说。",
                            Featured = false,
                            ImageUrl = "https://img.zcool.cn/community/01c56d6031ccc011013f3745e2d03d.png@1280w_1l_2o_100sh.png",
                            Title = "《西游记》"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "《水浒传》是元末明初施耐庵（现存刊本署名大多有施耐庵、罗贯中两人中的一人，或两人皆有）编著的章回体长篇小说。",
                            Featured = false,
                            ImageUrl = "https://img.zcool.cn/community/0100bc6031ccc111013ef90f03d56c.png@2o.png",
                            Title = "《水浒传》"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "《肖申克的救赎》The Shawshank Redemption 1994年这部被称为《刺激1995》的影片在中国影迷间也有极好的口碑，可见电影超越国界的神奇之处。",
                            Featured = false,
                            ImageUrl = "http://img.szjqz.net/image/movie/7718045224070cb7fa4bcae2c85467c9.jpg",
                            Title = "《肖申克的救赎》"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "《教父》The Godfather 1972年科波拉黑帮经典《教父》的首部，派拉蒙公司最成功的影片之一，坐稳IMDB头把交椅应属众望所归。",
                            Featured = true,
                            ImageUrl = "https://pic4.zhimg.com/v2-9db4ffdf47e979da4dd812ea09840162_qhd.jpg",
                            Title = "《教父》"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "《辛德勒的名单》Schindler's List 1993年斯皮尔伯格在《大白鲨》、《夺宝奇兵》、《外星人》、《紫色》四次与奥斯卡失之交臂后，终于在辛德勒和无数犹太难民的帮助下捧得金像。",
                            Featured = false,
                            ImageUrl = "https://pic.baike.soso.com/p/20120928/20120928185404-62640921.jpg",
                            Title = "《辛德勒的名单》"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "《荒野大镖客：救赎2》是一款由《GTA5》、《荒野大镖客：救赎》团队打造开发的第三人称射击游戏。",
                            Featured = false,
                            ImageUrl = "https://game.cdn.betophall.com/ckfinder/userfiles/images/video/20190925/D3.jpg",
                            Title = "《荒野大镖客》"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Description = "《真三国无双7》登场武将均来自古代中国大陆魏、吴、蜀三个国家。魏晋重要人物也会登场，这不禁让人感慨故事将会是多么的复杂纠结。",
                            Featured = true,
                            ImageUrl = "https://img.3dmgame.com/uploads/images/news/20181127/1543287200_943463.jpg",
                            Title = "《真三国无双》"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Description = "《使命召唤：战区2》是一款多人竞技类第一人称射击游戏，是《使命召唤：战区》的全新续作。",
                            Featured = false,
                            ImageUrl = "https://img.zcool.cn/community/0110f25747ee2c6ac72525ae4da6f7.jpg@1280w_1l_2o_100sh.jpg",
                            Title = "《使命召唤》"
                        });
                });

            modelBuilder.Entity("BlazorECommerce.Shared.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paperback"
                        },
                        new
                        {
                            Id = 3,
                            Name = "E-Book"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Audiobook"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Stream"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Blu-ray"
                        },
                        new
                        {
                            Id = 7,
                            Name = "VHS"
                        },
                        new
                        {
                            Id = 8,
                            Name = "PC"
                        },
                        new
                        {
                            Id = 9,
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Xbox"
                        });
                });

            modelBuilder.Entity("BlazorECommerce.Shared.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 2,
                            OriginalPrice = 19.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 3,
                            OriginalPrice = 0m,
                            Price = 7.99m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 4,
                            OriginalPrice = 29.99m,
                            Price = 19.99m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 2,
                            OriginalPrice = 14.99m,
                            Price = 7.99m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 2,
                            OriginalPrice = 0m,
                            Price = 6.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 5,
                            OriginalPrice = 0m,
                            Price = 3.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 6,
                            OriginalPrice = 0m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 7,
                            OriginalPrice = 0m,
                            Price = 19.99m
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 5,
                            OriginalPrice = 0m,
                            Price = 3.99m
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 5,
                            OriginalPrice = 0m,
                            Price = 2.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 8,
                            OriginalPrice = 29.99m,
                            Price = 19.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 9,
                            OriginalPrice = 0m,
                            Price = 69.99m
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 10,
                            OriginalPrice = 59.99m,
                            Price = 49.99m
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 8,
                            OriginalPrice = 24.99m,
                            Price = 9.99m
                        },
                        new
                        {
                            ProductId = 9,
                            ProductTypeId = 8,
                            OriginalPrice = 0m,
                            Price = 14.99m
                        });
                });

            modelBuilder.Entity("BlazorECommerce.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlazorECommerce.Shared.Product", b =>
                {
                    b.HasOne("BlazorECommerce.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BlazorECommerce.Shared.ProductVariant", b =>
                {
                    b.HasOne("BlazorECommerce.Shared.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorECommerce.Shared.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BlazorECommerce.Shared.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
