namespace BlazorECommerce.Server.Services.ProductServices;

public class ProductService:IProductService
{
    private readonly DataContext _context;
    public ProductService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>> { 
            Data = await _context.Products
            .Include(p => p.Variants)
            .ToListAsync() };
        return response;
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var response = new ServiceResponse<Product>();
        var product = await _context.Products
            .Include(p=>p.Variants)
            .ThenInclude(v=>v.ProductType)
            .FirstOrDefaultAsync(p=>p.Id.Equals(productId));
        if (product == null)
        {
            response.Success = false;
            response.Message = "Sorry, but this product does not exists";
        }
        else
        {
            response.Data = product;
        }
        return response;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(x => x.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync()
        };
        return response;
    }
    //分页查询
    public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText,int page)
    {
        var pageResults = 2f;//一页几条数据
        var pageCount = Math.Ceiling((await FindProductBySearchText(searchText)).Count / pageResults);//计算页总数
        var products =await _context.Products
            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                        || p.Description.ToLower().Contains(searchText.ToLower()))
            .Include(p => p.Variants)
            .Skip((page - 1) * (int)pageResults)//page为当前页，因此跳过前几页
            .Take((int)pageResults)
            .ToListAsync();

        var response = new ServiceResponse<ProductSearchResult>
        {
            Data = new ProductSearchResult
            {
                Products = products,
                CurrentPage = page,
                Pages = (int)pageCount
            }
        };
        return response;
    }

    private Task<List<Product>> FindProductBySearchText(string searchText)
    {
        return _context.Products
            .Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                        || p.Description.ToLower().Contains(searchText.ToLower()))
            .Include(p => p.Variants)
            .ToListAsync();
    }

    public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
    {
        var products = await FindProductBySearchText(searchText);
        List<string> result = new List<string>();
        foreach (var product in products)
        {
            if (product.Title.ToLower().Contains(searchText.ToLower()))
            {
                result.Add(product.Title);
            }

            if (product.Description != null)
            {
                var punctuation = product.Description.Where(char.IsPunctuation)
                    .Distinct().ToArray();//punctuation是标点符号
                var words = product.Description.Split()
                    .Select(s => s.Trim(punctuation));
                foreach (var word in words)
                {
                    if (word.ToLower().Contains(searchText.ToLower()) && !result.Contains(word))
                    {
                        result.Add(word);
                    }
                }
            }
        }

        return new ServiceResponse<List<string>> { Data = result };
    }

    public  async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
    {
        return new ServiceResponse<List<Product>>
        {
            Data = await _context.Products
                .Where(p=>p.Featured)
                .Include(p=>p.Variants)
                .ToListAsync()
        };
    }
}