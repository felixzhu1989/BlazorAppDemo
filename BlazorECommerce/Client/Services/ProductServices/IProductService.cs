namespace BlazorECommerce.Client.Services.ProductServices;

public interface IProductService
{
    event Action ProductsChanged;//当Products发生改变时需要及时更新
    public List<Product> Products { get; set; }
    Task GetProductsAsync(string? categoryUrl=null);//如果给null就是获取所有的
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
}