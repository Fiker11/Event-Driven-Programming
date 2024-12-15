using System;
using System.Threading;

public class Stopwatch
{
    //Fields    
    public TimeSpan TimeElapsed { get; private set; } = TimeSpan.Zero;
    private bool _isRunning = false;

    //delegate and events
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;


    public void Start()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
            StartTicking();
        }

    }

    public void Stop()
    {
        if (_isRunning)
        {
            _isRunning = false;
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
        else
        {
            Console.WriteLine("Stopwatch is already stopped.");
        }
    }

    public void Reset()
    {
        Stop();
        TimeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    private void StartTicking()
    {
        new Thread(() =>
        {
            while (_isRunning)
            {
                Thread.Sleep(1000);
                TimeElapsed = TimeElapsed.Add(TimeSpan.FromSeconds(1));
                Console.Write($"\rElapsed Time: {TimeElapsed:mm\\:ss}     ");
            }
        }).Start();
    }
}

