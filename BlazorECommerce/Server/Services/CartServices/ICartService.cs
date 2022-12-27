namespace BlazorECommerce.Server.Services.CartServices;

public interface ICartService
{
    Task<ServiceResponse<List<CartProductResponse>>> GetCartResponse(List<CartItem> cartItems);
    Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems);
    Task<ServiceResponse<int>> GetCartItemsCount();
    Task<ServiceResponse<List<CartProductResponse>>> GetDbCartResponse();
    Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
    Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);
    Task<ServiceResponse<bool>> RemoveItemFromCart(int productId,int productTypeId);
}