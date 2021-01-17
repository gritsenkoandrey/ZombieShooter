using UnityEngine;
using Interfaces;


public class CameraController: IInitialization, ILateExecute
{
    private Transform _playerTransform;
    private Vector3 _tempPos;

    public void Initialization()
    {
        _playerTransform = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
    }

    public void LateExecute()
    {
        if (LevelController.Instanse.typeGameGoal != TypeGameGoal.DEFEND_FENCE 
            && LevelController.Instanse.typeGameGoal != TypeGameGoal.GAME_OVER)
        {
            if (_playerTransform)
            {
                _tempPos = Services.Instance.CameraServices.CameraMain.transform.position;
                _tempPos.x = _playerTransform.position.x;
                Services.Instance.CameraServices.CameraMain.transform.position = _tempPos;
            }
        }
    }
}