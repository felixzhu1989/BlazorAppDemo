namespace BlazorECommerce.Shared;

public class ProductSearchResult
{
    //充当Dto（数据传输对象）的作用
    public List<Product> Products { get; set; } = new();
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
}