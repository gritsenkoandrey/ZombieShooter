using Interfaces;
using UnityEngine;


public class InputController: IExecute
{
    private PlayerData _playerData;
    private Vector2 _input;

    public InputController()
    {
        _playerData = Data.Instance.PlayerData;
        _playerData.Initialization();
    }

    public void Execute()
    {
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR || UNITY_WSA

        _input.x = Input.GetAxis(AxisManager.HORIZONTAL);
        _input.y = Input.GetAxis(AxisManager.VERTICAL);

        _playerData.PlayerMove.Execute(_input);

#endif

#if UNITY_IOS || UNITY_ANDROID

#endif
    }
}