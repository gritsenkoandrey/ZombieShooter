using UnityEngine;


public sealed class TimeService : ITimeService
{
    private int _deltaTimeResetFrame;

    public float DeltaTime()
    {
        return _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.deltaTime;
    }

    public float FixedDeltaTime()
    {
        return _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.fixedDeltaTime;
    }

    public float GameTime()
    {
        return Time.time;
    }

    public float RealtimeSinceStartup()
    {
        return Time.realtimeSinceStartup;
    }

    public void ResetDeltaTime()
    {
        _deltaTimeResetFrame = Time.frameCount;
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public float UnscaledDeltaTime()
    {
        return _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.unscaledDeltaTime;
    }
}