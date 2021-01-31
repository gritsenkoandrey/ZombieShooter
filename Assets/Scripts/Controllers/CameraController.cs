using UnityEngine;
using Interfaces;


public class CameraController: IInitialization, ILateExecute, IInitializationPlayer
{
    private Transform _playerTransform;
    private Vector3 _tempPos;

    public void Initialization()
    {
        EventBus.Subscribe(this);
    }

    public void LateExecute()
    {
        if (Data.Instance.LevelData.typeGameGoal != TypeGameGoal.DEFEND_FENCE
            && Data.Instance.LevelData.typeGameGoal != TypeGameGoal.GAME_OVER)
        {
            if (_playerTransform)
            {
                _tempPos = Services.Instance.CameraServices.CameraMain.transform.position;
                _tempPos.x = _playerTransform.position.x;
                Services.Instance.CameraServices.CameraMain.transform.position = _tempPos;
            }
        }
    }

    public void InitializationPlayer()
    {
        _playerTransform = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
    }
}