namespace BlazorECommerce.Server.Services.ProductServices;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
    Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
    //Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);//修改为如下分页查询
    Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText,int page);
    Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
    Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
}