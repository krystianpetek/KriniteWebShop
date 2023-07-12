namespace KriniteWebShop.WebBlazorClient.State;

public interface ICartState
{
    event Action? CartStateUpdated;
    void UpdateCartState();
    int CartItems { get; set; }
    void SetState(int value);
}
