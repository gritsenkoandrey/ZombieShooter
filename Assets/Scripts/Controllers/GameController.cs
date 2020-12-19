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
        for (var i = 0; i < _controllers.Length; i++)
        {
            _controllers[i].Execute();
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