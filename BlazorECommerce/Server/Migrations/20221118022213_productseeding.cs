using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class productseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "《三国演义》是元末明初小说家罗贯中根据陈寿《三国志》和裴松之注解以及民间三国故事传说经过艺术加工创作而成的长篇章回体历史演义小说。", "https://img.zcool.cn/community/01848c6031ccc011013ef90f6b3643.png@2o.png", 9.99m, "《三国演义》" },
                    { 2, "《西游记》是明代吴承恩创作的中国古代第一部浪漫主义章回体长篇神魔小说。", "https://img.zcool.cn/community/01c56d6031ccc011013f3745e2d03d.png@1280w_1l_2o_100sh.png", 7.99m, "《西游记》" },
                    { 3, "《水浒传》是元末明初施耐庵（现存刊本署名大多有施耐庵、罗贯中两人中的一人，或两人皆有）编著的章回体长篇小说。", "https://img.zcool.cn/community/0100bc6031ccc111013ef90f03d56c.png@2o.png", 6.99m, "《水浒传》" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
