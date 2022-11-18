using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorECommerce.Shared;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = String.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    //一个Category对应多个Product
    public Category? Category { get; set; }
    public int CategoryId { get; set; }//显式指定外键
}