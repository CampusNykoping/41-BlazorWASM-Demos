
using Microsoft.AspNetCore.Components;

namespace PomodoroTimer.Pages;

public class TimerBase : ComponentBase, IDisposable
{
    private int timeLeft = 25 * 60; // Tid i sekunder
    protected string remaining => TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");
    PeriodicTimer? timer;

    protected async Task Start()
    {
        timer?.Dispose();
        timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

        while (await timer.WaitForNextTickAsync())
        {
            if (timeLeft > 0)
            {
                timeLeft -= 1;
                await InvokeAsync(StateHasChanged);
            }
        }
    }

    protected void Stop()
    {
        timer?.Dispose();
    }

    public void Dispose()
    {
        timer?.Dispose();
    }
}
