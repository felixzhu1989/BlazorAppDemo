﻿namespace BlazorECommerce.Server.Services.CartServices;

public class CartService:ICartService
{
    private readonly DataContext _context;
    public CartService(DataContext context)
    {
        _context = context;
    }
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
}