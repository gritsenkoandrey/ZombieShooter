using System.Collections.Generic;


public class SubscribersList<TSubscriber> where TSubscriber : class
{
    private bool _isNeedCleanup = false;
    public bool isExecuting;
    public readonly List<TSubscriber> list = new List<TSubscriber>();

    public void Add(TSubscriber subscriber)
    {
        list.Add(subscriber);
    }

    public void Remove(TSubscriber subscriber)
    {
        if (isExecuting)
        {
            var i = list.IndexOf(subscriber);
            if (i >= 0)
            {
                _isNeedCleanup = true;
                list[i] = null;
            }
        }
        else
        {
            list.Remove(subscriber);
        }
    }

    public void Cleanup()
    {
        if (!_isNeedCleanup)
        {
            return;
        }

        list.RemoveAll(s => s == null);
        _isNeedCleanup = false;
    }
}