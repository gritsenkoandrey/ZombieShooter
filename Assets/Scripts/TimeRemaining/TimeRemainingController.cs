using System.Collections.Generic;
using Interfaces;


public sealed class TimeRemainingController : IExecute
{
    private readonly List<ITimeRemaining> _timeRemainings;
    private readonly ITimeService _timeService;

    public TimeRemainingController()
    {
        _timeRemainings = TimeRemainingExtensions.TimeRemainings;
        _timeService = Services.Instance.TimeService;
    }

    public void Execute()
    {
        var time = _timeService.DeltaTime();
        for (int i = 0; i < _timeRemainings.Count; i++)
        {
            var obj = _timeRemainings[i];
            obj.CurrentTime -= time;
            if (obj.CurrentTime <= 0.0f)
            {
                obj?.Method?.Invoke();
                if (!obj.IsRepeating)
                {
                    obj.RemoveTimeRemaining();
                }
                else
                {
                    obj.CurrentTime = obj.Time;
                }
            }
        }
    }
}