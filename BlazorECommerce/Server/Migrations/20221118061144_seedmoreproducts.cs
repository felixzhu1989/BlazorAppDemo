using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class seedmoreproducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, 2, "《肖申克的救赎》The Shawshank Redemption 1994年这部被称为《刺激1995》的影片在中国影迷间也有极好的口碑，可见电影超越国界的神奇之处。", "http://img.doooor.com/img/forum/201706/23/022945t2ceojyziumuo85i.jpg", 6.99m, "《肖申克的救赎》" },
                    { 5, 2, "《教父》The Godfather 1972年科波拉黑帮经典《教父》的首部，派拉蒙公司最成功的影片之一，坐稳IMDB头把交椅应属众望所归。", "https://pic4.zhimg.com/v2-9db4ffdf47e979da4dd812ea09840162_qhd.jpg", 6.99m, "《教父》" },
                    { 6, 2, "《辛德勒的名单》Schindler's List 1993年斯皮尔伯格在《大白鲨》、《夺宝奇兵》、《外星人》、《紫色》四次与奥斯卡失之交臂后，终于在辛德勒和无数犹太难民的帮助下捧得金像。", "https://pic.baike.soso.com/p/20120928/20120928185404-62640921.jpg", 6.99m, "《辛德勒的名单》" },
                    { 7, 3, "《荒野大镖客：救赎2》是一款由《GTA5》、《荒野大镖客：救赎》团队打造开发的第三人称射击游戏。", "https://www.gamersky.com/showimage/id_gamersky.shtml?https://imgs.gamersky.com/ku/2018/ku_reddeadredemption_b.jpg", 6.99m, "《荒野大镖客》" },
                    { 8, 3, "《真三国无双7》登场武将均来自古代中国大陆魏、吴、蜀三个国家。魏晋重要人物也会登场，这不禁让人感慨故事将会是多么的复杂纠结。", "https://www.gamersky.com/showimage/id_gamersky.shtml?https://imgs.gamersky.com/ku/2013/ku_z357_b.jpg", 6.99m, "《真三国无双》" },
                    { 9, 3, "《使命召唤：战区2》是一款多人竞技类第一人称射击游戏，是《使命召唤：战区》的全新续作。", "https://www.gamersky.com/showimage/id_gamersky.shtml?https://imgs.gamersky.com/upimg/new_preview/2022/09/16/origin_b_202209161028006305_b.jpg", 6.99m, "《使命召唤》" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
