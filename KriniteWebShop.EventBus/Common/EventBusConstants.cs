using KriniteWebShop.EventBus.Events;

namespace KriniteWebShop.EventBus.Common;
public static class EventBusConstants
{
    public const string CartCheckoutQueue = $"{nameof(CartCheckoutEvent)}-queue";
}
