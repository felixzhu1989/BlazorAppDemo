namespace BlazorECommerce.Client.Services.CategoryServices;

public class CategoryService: ICategoryService
{
    private readonly HttpClient _http;
    public CategoryService(HttpClient http)
    {
        _http = http;
    }
    public List<Category> Categories { get; set; } = new();
    public async Task GetCategories()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
        if (result is { Data: { } }) Categories = result.Data;
    }
}