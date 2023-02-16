using KriniteWebShop.EventBus.Events;
using KriniteWebShop.ProductCart.API.Entities;

namespace KriniteWebShop.ProductCart.API.Mappings;

public static class CartMapper
{
    public static CartCheckoutEvent MapToCartCheckoutEvent(this CartCheckout cartCheckout)
    {
        return new CartCheckoutEvent
        {
            AddressLine = cartCheckout?.AddressLine,
            CardName = cartCheckout?.CardName,
            CardNumber = cartCheckout?.CardNumber,
            Country = cartCheckout?.Country,
            CVV = cartCheckout?.CVV,
            EmailAddress = cartCheckout?.EmailAddress,
            Expiration = cartCheckout?.Expiration,
            FirstName = cartCheckout?.FirstName,
            LastName = cartCheckout?.LastName,
            PaymentMethod = cartCheckout.PaymentMethod.Value,
            State = cartCheckout?.State,
            TotalPrice = cartCheckout.TotalPrice,
            UserName = cartCheckout?.UserName,
            ZipCode = cartCheckout?.ZipCode,
        };
    }

    public static ShoppingCart MapToShoppingCart(this RestShoppingCart restShoppingCart, string userName) {
        return new ShoppingCart
        {
            Items = restShoppingCart.Items,
            UserName = userName
        };
    }
}
