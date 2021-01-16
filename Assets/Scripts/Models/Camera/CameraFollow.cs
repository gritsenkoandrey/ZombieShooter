using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _tempPos;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
    }

    private void LateUpdate()
    {
        if (LevelController.Instanse.typeGameGoal != TypeGameGoal.DEFEND_FENCE
            && LevelController.Instanse.typeGameGoal != TypeGameGoal.GAME_OVER)
        {
            if (_playerTransform)
            {
                _tempPos = transform.position;
                _tempPos.x = _playerTransform.position.x;
                transform.position = _tempPos;
            }
        }
    }
}