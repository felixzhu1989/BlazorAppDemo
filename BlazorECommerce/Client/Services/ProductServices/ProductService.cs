namespace BlazorECommerce.Client.Services.ProductServices;

public class ProductService:IProductService
{
    private readonly HttpClient _http;
    public ProductService(HttpClient http)
    {
        _http = http;
    }
    public event Action? ProductsChanged;
    public List<Product> Products { get; set; } = new();
    public string Message { get; set; } = "Loading Products...";

    public async Task GetProductsAsync(string? categoryUrl = null)
    {
        var result = categoryUrl==null?
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product"):
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/category/{categoryUrl}");
        //result is {Data: { } }是(result != null && result.Data!=null)的简化
        if (result is { Data: { } }) Products = result.Data;
        ProductsChanged?.Invoke();//发出属性变更事件，告诉事件订阅者，需要开始干活了
    }
    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
        return result;
    }

    public async Task SearchProducts(string searchText)
    {
        var result =await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/search/{searchText}");
        if (result is { Data: { } }) Products = result.Data;
        if (Products.Count == 0) Message = "No products found.";
        ProductsChanged?.Invoke();
    }

    public async Task<List<string>> GetProductSearchSuggestions(string searchText)
    {
       var result= await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Product/searchsuggestions/{searchText}");
       return result!.Data!;
    }
}