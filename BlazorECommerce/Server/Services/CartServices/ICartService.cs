namespace BlazorECommerce.Server.Services.CartServices;

public interface ICartService
{
    Task<ServiceResponse<List<CartProductResponse>>> GetCartResponse(List<CartItem> cartItems);
}