namespace BlazorECommerce.Server.Services.CategoryServices;

public class CategoryService: ICategoryService
{
    private readonly DataContext _context;
    public CategoryService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
    {
        return new ServiceResponse<List<Category>> { Data = await _context.Categories.ToListAsync() };
    }
}