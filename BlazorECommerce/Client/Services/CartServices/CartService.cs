using BlazorECommerce.Shared;
using Blazored.LocalStorage;

namespace BlazorECommerce.Client.Services.CartServices;

public class CartService:ICartService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;

    public CartService(ILocalStorageService localStorage,HttpClient Http,AuthenticationStateProvider authStateProvider)
    {
        _localStorage = localStorage;
        _http = Http;
        _authStateProvider = authStateProvider;
    }
    public event Action? OnChange;

    private async Task<bool> IsUserAuthenticated()
    {
        return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity!.IsAuthenticated;
    }

    public async Task AddToCart(CartItem cartItem)
    {
        if (await IsUserAuthenticated())
        {
            //Console.WriteLine("User is authenticated.");
            //登录状态时添加到数据库
            await _http.PostAsJsonAsync("api/cart/add", cartItem);
        }
        else
        {
            //Console.WriteLine("User is NOT authenticated.");
            //非登录状态则添加到本地存储
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();
            //判断是否有相同的商品存在
            var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId
                                          && x.ProductTypeId == cartItem.ProductTypeId);
            if (sameItem == null) cart.Add(cartItem);//不存在相同的商品则添加
            else sameItem.Quantity+=cartItem.Quantity;//存在相同的商品则增加商品数量

            await _localStorage.SetItemAsync("cart", cart);
        }
        //OnChange.Invoke();
        await GetCartItemsCount();
    }

    //public async Task<List<CartItem>> GetCartItems()
    //{
    //    await GetCartItemsCount();
    //    var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();
    //    return cart;
    //}

    public async Task<List<CartProductResponse>> GetCartProducts()
    {
        if (await IsUserAuthenticated())
        {
            var responses = await _http.GetFromJsonAsync<ServiceResponse<List<CartProductResponse>>>("api/cart");
            return responses.Data;
        }
        else
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cartItems == null) return new List<CartProductResponse>();
            var responses = await _http.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts = await responses.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
            return cartProducts.Data;
        }
    }

    public async Task RemoveProductFromCart(int productId, int productTypeId)
    {
        if (await IsUserAuthenticated())
        {
            await _http.DeleteAsync($"api/Cart/{productId}/{productTypeId}");
        }
        else
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart==null) return;
            var cartItem = cart.Find(x => x.ProductId == productId
                                          && x.ProductTypeId == productTypeId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);//移除cartitem
                //更新本地存储
                await _localStorage.SetItemAsync("cart", cart);
            }
        }
        //通知购物车按钮更新计数
        //OnChange.Invoke();
        //修改成获取购物车计数
        //因为前端删除CartItem时调用了LoadCart()中包含了GetCartItemsCount()，因此注释掉
        //await GetCartItemsCount();
    }

    public async Task UpdateQuantity(CartProductResponse product)
    {
        if (await IsUserAuthenticated())
        {
            var request = new CartItem
            {
                ProductId = product.ProductId, Quantity = product.Quantity, ProductTypeId = product.ProductTypeId
            };
            await _http.PutAsJsonAsync("api/cart/update-quantity", request);
        }
        else
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

    public async Task StoreCartItems(bool emptyLocalCart=false)
    {
        var localCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if(localCart==null) return;
        //将本地购物车存储到数据库中
        await _http.PostAsJsonAsync("api/cart", localCart);
        if (emptyLocalCart)
        {
            await _localStorage.RemoveItemAsync("cart");//清空本地购物车
        }
    }

    public async Task GetCartItemsCount()
    {
        if (await IsUserAuthenticated())
        {
            //授权则从数据库获取购物车商品计数
            var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/Cart/count");
            var count = result.Data;
            await _localStorage.SetItemAsync<int>("cartItemsCount", count);//将购物车数量添加到本地存储
        }
        else
        {
            //未被授权则从本地存储获取购物车计数
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            await _localStorage.SetItemAsync<int>("cartItemsCount", cart?.Count ?? 0);
        }
        OnChange.Invoke();
    }
}