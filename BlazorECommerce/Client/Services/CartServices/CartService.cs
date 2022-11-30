using BlazorECommerce.Shared;
using Blazored.LocalStorage;

namespace BlazorECommerce.Client.Services.CartServices;

public class CartService:ICartService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;

    public CartService(ILocalStorageService localStorage,HttpClient Http)
    {
        _localStorage = localStorage;
        _http = Http;
    }
    public event Action? OnChange;
    public async Task AddToCart(CartItem cartItem)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();
        //判断是否有相同的商品存在
        var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId
                                      && x.ProductTypeId == cartItem.ProductTypeId);
        if (sameItem == null) cart.Add(cartItem);//不存在相同的商品则添加
        else sameItem.Quantity+=cartItem.Quantity;//存在相同的商品则增加商品数量

        await _localStorage.SetItemAsync("cart", cart);
        OnChange.Invoke();
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();
        return cart;
    }

    public async Task<List<CartProductResponse>> GetCartProducts()
    {
        var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        var responses = await _http.PostAsJsonAsync("api/cart/products", cartItems);
        var cartProducts = await responses.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
        return cartProducts.Data;
    }

    public async Task RemoveProductFromCart(int productId, int productTypeId)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if(cart==null)return;
        var cartItem = cart.Find(x => x.ProductId == productId
                                      && x.ProductTypeId == productTypeId);
        if (cartItem != null)
        {
            cart.Remove(cartItem);//移除cartitem
            //更新本地存储
            await _localStorage.SetItemAsync("cart",cart);
            //通知购物车按钮更新计数
            OnChange.Invoke();
        }
    }

    public async Task UpdateQuantity(CartProductResponse product)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart==null) return;
        var cartItem = cart.Find(x => x.ProductId == product.ProductId
                                      && x.ProductTypeId == product.ProductTypeId);
        if (cartItem != null)
        {
            cartItem.Quantity=product.Quantity;//更新数量
            //更新本地存储
            await _localStorage.SetItemAsync("cart", cart);
        }
    }
}