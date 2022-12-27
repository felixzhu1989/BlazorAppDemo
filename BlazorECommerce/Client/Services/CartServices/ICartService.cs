namespace BlazorECommerce.Client.Services.CartServices;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(CartItem cartItem);
    //Task<List<CartItem>> GetCartItems();//合并到GetCartProducts()中
    Task<List<CartProductResponse>> GetCartProducts();
    Task RemoveProductFromCart(int productId,int productTypeId);
    Task UpdateQuantity(CartProductResponse product);
    Task StoreCartItems(bool emptyLocalCart);
    Task GetCartItemsCount();
}