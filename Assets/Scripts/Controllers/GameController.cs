using UnityEngine;


public sealed class GameController : MonoBehaviour
{
    private Controllers _controllers;

    private void Awake()
    {
        _controllers = new Controllers();
        Initialization();
        Cleaner();
    }

    private void Update()
    {
        for (var i = 0; i < _controllers.ExeLength; i++)
        {
            _controllers[(int)i].Execute();
        }
    }

    private void FixedUpdate()
    {
        for (var i = 0; i < _controllers.FixLength; i++)
        {
            _controllers[(byte)i].FixExecute();
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < _controllers.LateLength; i++)
        {
            _controllers[(short)i].LateExecute();
        }
    }

    public void Cleaner()
    {
        _controllers.Cleaner();
    }

    public void Initialization()
    {
        _controllers.Initialization();
    }
}