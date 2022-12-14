namespace BlazorECommerce.Client.Services.ProductServices;

public interface IProductService
{
    event Action ProductsChanged;//当Products发生改变时需要及时更新
    List<Product> Products { get; set; }
    string Message { get; set; }
    int CurrentPage { get; set; }
    int PageCount { get; set; }
    string LastSearchText { get; set; }

    Task GetProductsAsync(string? categoryUrl=null);//如果给null就是获取所有的
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
    Task SearchProducts(string searchText,int page);
    Task<List<string>> GetProductSearchSuggestions(string searchText);
}