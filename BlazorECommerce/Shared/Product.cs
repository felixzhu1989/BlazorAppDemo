namespace BlazorECommerce.Shared;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    //Price转移到了ProductVariant中
    //[Column(TypeName = "decimal(18,2)")]
    //public decimal Price { get; set; }

    public bool Featured { get; set; } = false;//特征，比如热门
    
    //一个Category对应多个Product
    public Category? Category { get; set; }
    public int CategoryId { get; set; }//显式指定外键

    public List<ProductVariant> Variants { get; set; } = new();
}