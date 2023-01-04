using KriniteWebShop.ProductCart.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace KriniteWebShop.ProductCart.API.Repositories;

public class CartRepository : ICartRepository
{
    private readonly IDistributedCache _distributedCache;
    public CartRepository(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
    }

    public async Task<ShoppingCart> GetCart(string userName)
    {
        var cache = await _distributedCache.GetStringAsync(userName);
        if (string.IsNullOrWhiteSpace(cache))
            return default;

        return JsonSerializer.Deserialize<ShoppingCart>(cache);
    }

    public async Task<ShoppingCart> UpdateCart(ShoppingCart cart)
    {
        await _distributedCache.SetStringAsync(cart?.UserName, JsonSerializer.Serialize<ShoppingCart>(cart));
        return await GetCart(cart?.UserName);
    }

    public async Task DeleteCart(string userName)
    {
        await _distributedCache.RemoveAsync(userName);
    }
}
