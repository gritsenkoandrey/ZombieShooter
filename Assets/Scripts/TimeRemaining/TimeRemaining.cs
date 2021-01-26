using System;


public sealed class TimeRemaining : ITimeRemaining
{
    public Action Method { get; }
    public float Time { get; }
    public float CurrentTime { get; set; }
    public bool IsRepeating { get; }

    public TimeRemaining(Action method, float time, bool isRepeating = false)
    {
        Method = method;
        Time = time;
        CurrentTime = time;
        IsRepeating = isRepeating;
    }
}