using UnityEngine;


public class ZombieMove : MonoBehaviour
{
    private Vector3 _tempPos;
    private Vector3 _tempScale;
    private float _correctionDis = 0.25f;

    private float _speed = 1.0f;

    public void MoveZombie(Transform targetTransform)
    {
        Flip(targetTransform);
        Move(targetTransform);
    }

    private void Flip(Transform targetTransform)
    {
        _tempPos = transform.position;
        _tempScale = transform.localScale;

        if (targetTransform.position.x > _tempPos.x + _correctionDis)
        {
            _tempScale.x = -1.0f;
        }
        else if (targetTransform.position.x < _tempPos.x - _correctionDis)
        {
            _tempScale.x = 1.0f;
        }

        transform.localScale = _tempScale;
    }

    private void Move(Transform targetTransform)
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(targetTransform.position.x, targetTransform.position.y, 0.0f), _speed * Time.deltaTime);
    }
}