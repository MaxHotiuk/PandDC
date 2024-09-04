using System.Diagnostics;
namespace LabWork1MatrixSumSub.ClassesLibrary;
public class Timer
{
    private readonly Stopwatch _stopwatch = new();
    public void Start()
    {
        _stopwatch.Start();
    }

    public void Stop()
    {
        _stopwatch.Stop();
    }

    public void Reset()
    {
        _stopwatch.Reset();
    }

    public float GetElapsedMilliseconds()
    {
        return _stopwatch.ElapsedMilliseconds;
    }
    
    public float GetElapsedSeconds()
    {
        return _stopwatch.ElapsedMilliseconds / 1000f;
    }
}