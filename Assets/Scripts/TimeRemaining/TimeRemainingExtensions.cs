using System.Collections.Generic;


public static partial class TimeRemainingExtensions
{
    private static readonly List<ITimeRemaining> _timeRemainings = new List<ITimeRemaining>(10);

    public static List<ITimeRemaining> TimeRemainings
    {
        get { return _timeRemainings; }
    }

    public static void AddTimeRemaining(this ITimeRemaining time)
    {
        if (_timeRemainings.Contains(time))
        {
            return;
        }

        time.CurrentTime = time.Time;
        _timeRemainings.Add(time);
    }

    public static void RemoveTimeRemaining(this ITimeRemaining time)
    {
        if (!_timeRemainings.Contains(time))
        {
            return;
        }

        _timeRemainings.Remove(time);
    }
}