namespace KriniteWebShop.WebBlazorClient.Services.Interfaces;

public interface ICartState
{
    event Action? CartStateUpdated;
    void UpdateCartState();
    int CartItems { get; set; }
    void SetState(int value);
}
