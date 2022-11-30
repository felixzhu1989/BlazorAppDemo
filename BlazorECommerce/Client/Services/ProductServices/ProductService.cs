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
    public int CurrentPage { get; set; } = 1;
    public int PageCount { get; set; } = 0;
    public string LastSearchText { get; set; }=string.Empty;

    public async Task GetProductsAsync(string? categoryUrl = null)
    {
        var result = categoryUrl==null?
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured"):
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/category/{categoryUrl}");
        //result is {Data: { } }是(result != null && result.Data!=null)的简化
        if (result is { Data: { } }) Products = result.Data;
        CurrentPage = 1;
        PageCount = 0;
        if (Products.Count == 0)
        {
            Message = "No products found.";
        }

        ProductsChanged?.Invoke();//发出属性变更事件，告诉事件订阅者，需要开始干活了
    }
    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
        return result;
    }
    //分页查询
    public async Task SearchProducts(string searchText,int page)
    {
        LastSearchText = searchText;//查询字符串赋值
        var result =await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/Product/search/{searchText}/{page}");
        if (result is { Data: { } })
        {
            Products = result.Data.Products;//商品列表
            CurrentPage=result.Data.CurrentPage;//当前页码
            PageCount = result.Data.Pages;//总页数
        }
        if (Products.Count == 0) Message = "No products found.";
        ProductsChanged?.Invoke();
    }

    public async Task<List<string>> GetProductSearchSuggestions(string searchText)
    {
       var result= await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Product/searchsuggestions/{searchText}");
       return result!.Data!;
    }
}