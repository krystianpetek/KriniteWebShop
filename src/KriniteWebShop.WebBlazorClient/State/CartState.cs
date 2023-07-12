namespace KriniteWebShop.WebBlazorClient.State;

public class CartState : ICartState
{
    public int CartItems { get; set; } = 0;

    public void SetState(int value)
    {
        CartItems = value;
        UpdateCartState();
    }

    public event Action? CartStateUpdated;

    public void UpdateCartState()
    {
        CartStateUpdated?.Invoke();
    }
}
