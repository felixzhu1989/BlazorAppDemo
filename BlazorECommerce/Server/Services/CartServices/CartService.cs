using BlazorECommerce.Shared;
using System.Security.Claims;

namespace BlazorECommerce.Server.Services.CartServices;

public class CartService:ICartService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(DataContext context,IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    //通过HttpContextAccessor获取用户Id
    private int GetUserId() =>
        int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    public async Task<ServiceResponse<List<CartProductResponse>>> GetCartResponse(List<CartItem> cartItems)
    {
        var result = new ServiceResponse<List<CartProductResponse>>
        {
            Data = new List<CartProductResponse>()
        };
        foreach (var item in cartItems)
        {
            var product = await _context.Products
                .Where(p => p.Id == item.ProductId)
                .FirstOrDefaultAsync();
            if(product==null)continue;
            var productVariant = await _context.ProductVariants
                .Where(v => v.ProductId == item.ProductId
                            && v.ProductTypeId == item.ProductTypeId)
                .Include(v => v.ProductType)
                .FirstOrDefaultAsync();
            if(productVariant==null)continue;
            //将上述两个对象组合成一个对象
            var cartProduct = new CartProductResponse()
            {
                ProductId = product.Id,
                Title = product.Title,
                ImageUrl = product.ImageUrl,
                ProductTypeId = productVariant.ProductTypeId,
                ProductType = productVariant.ProductType.Name,
                Price = productVariant.Price,
                Quantity = item.Quantity
            };
            result.Data.Add(cartProduct);
        }
        return result;
    }

    public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems)
    {
        cartItems.ForEach(x=>x.UserId=GetUserId());
        _context.CartItems.AddRange(cartItems);
        await _context.SaveChangesAsync();
        //return await GetCartResponse(await _context.CartItems.Where(x => x.UserId.Equals(GetUserId())).ToListAsync());
        return await GetDbCartResponse();
    }

    public async Task<ServiceResponse<int>> GetCartItemsCount()
    {
        var count = (await _context.CartItems.Where(x => x.UserId.Equals(GetUserId())).ToListAsync()).Count;
        return new ServiceResponse<int> { Data = count };
    }

    public async Task<ServiceResponse<List<CartProductResponse>>> GetDbCartResponse()
    {
        return await GetCartResponse(await _context.CartItems.Where(x => x.UserId.Equals(GetUserId())).ToListAsync());
    }

    public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
    {
        cartItem.UserId = GetUserId();
        var sameItem = await _context.CartItems
            .FirstOrDefaultAsync(x => x.ProductId.Equals(cartItem.ProductId)
                                      && x.ProductTypeId.Equals(cartItem.ProductTypeId)
                                      && x.UserId.Equals(cartItem.UserId));
        if (sameItem == null)
        {
            _context.CartItems.Add(cartItem);
        }
        else
        {
            sameItem.Quantity += cartItem.Quantity;
        }
        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true };
    }

    public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
    {
        var sameItem = await _context.CartItems
            .FirstOrDefaultAsync(x => x.ProductId.Equals(cartItem.ProductId)
                                      && x.ProductTypeId.Equals(cartItem.ProductTypeId)
                                      && x.UserId.Equals(GetUserId()));
        if (sameItem == null)
        {
            return new ServiceResponse<bool> { Data = false,Success = false,Message = "CartItem does not exist."};
        }
        sameItem.Quantity = cartItem.Quantity;
        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true};
    }

    public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
    {
        var sameItem = await _context.CartItems
            .FirstOrDefaultAsync(x => x.ProductId.Equals(productId)
                                      && x.ProductTypeId.Equals(productTypeId)
                                      && x.UserId.Equals(GetUserId()));
        if (sameItem == null)
        {
            return new ServiceResponse<bool> { Data = false, Success = false, Message = "CartItem does not exist." };
        }

        _context.CartItems.Remove(sameItem);
        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true };
    }
}