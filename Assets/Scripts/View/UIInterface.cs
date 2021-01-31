using UnityEngine;


public sealed class UIInterface
{
    private UICounter _uICounter;

    public UICounter UICounter
    {
        get
        {
            if (!_uICounter)
            {
                _uICounter = Object.FindObjectOfType<UICounter>();
            }
            return _uICounter;
        }
    }
}