using System.Timers;

namespace Timer.Services;

public class TokenTimer
{
    private System.Timers.Timer _timer;

    public void SetTimer(double interval)
    {
        _timer = new System.Timers.Timer(interval);
        _timer.Elapsed += NotifyTimerElapsed;
        _timer.Enabled = true;
    }

    public event Action OnElapsed;

    private void NotifyTimerElapsed(Object source, ElapsedEventArgs e)
    {
        OnElapsed?.Invoke();
        _timer.Dispose();
    }
}