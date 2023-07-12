using Microsoft.AspNetCore.Components;
using System.Threading;
using System.Timers;

namespace KriniteWebShop.WebBlazorClient.Components;

public partial class Countdown : ComponentBase, IDisposable
{
    private System.Timers.Timer timer = null;
    private int _secondsToRun = 0;
    protected string Time { get; set; } = "00:00";

    public void Dispose()
    {
        timer.Dispose();
    }

    [Parameter]
    public EventCallback TimerOut { get; set; }

    protected override void OnInitialized()
    {
        timer = new System.Timers.Timer(1000);
        timer.Elapsed += OnTimerEvent;
        timer.AutoReset = true;

        base.OnInitialized();
    }

    private async void OnTimerEvent(object? sender, ElapsedEventArgs e)
    {
        _secondsToRun--;
        await InvokeAsync(() =>
        {
            Time = TimeSpan.FromSeconds(_secondsToRun).ToString($"mm:ss");
            StateHasChanged();
        });

        if(_secondsToRun <= 0) { 
        timer.Stop();
            await TimerOut.InvokeAsync();
        }
    }

    public void Start(int secondsToRun)
    {
        _secondsToRun = secondsToRun;

        if (_secondsToRun > 0)
        {
            Time = TimeSpan.FromSeconds(_secondsToRun).ToString(@"mm\:ss");
            StateHasChanged();
            timer.Start();
        }
    }

}