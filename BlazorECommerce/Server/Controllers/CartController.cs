using System.Security.Claims;
using BlazorECommerce.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;
    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetDbCartProducts()
    {
        var result= await _cartService.GetDbCartResponse();
        return Ok(result);
    }
    [HttpGet("count")]
    public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
    {
        return await _cartService.GetCartItemsCount();
    }

    [HttpPost("add")]
    public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(
        CartItem cartItem)
    {
        return await _cartService.AddToCart(cartItem);
    }

    [HttpPost("products")]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts(
        List<CartItem> cartItems)
    {
        var result =await _cartService.GetCartResponse(cartItems);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItems(
        List<CartItem> cartItems)
    {
        //var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var result = await _cartService.StoreCartItems(cartItems);
        return Ok(result);
    }

    [HttpPut("update-quantity")]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(
        CartItem cartItem)
    {
        return await _cartService.UpdateQuantity(cartItem);
    }

    [HttpDelete("{productId}/{productTypeId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId, int productTypeId)
    {
        return await _cartService.RemoveItemFromCart(productId,productTypeId);
    }
}