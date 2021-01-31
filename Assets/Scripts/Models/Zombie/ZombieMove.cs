using UnityEngine;


public sealed class ZombieMove : ZombieBase
{
    [SerializeField] private Zombie _zombie = null;

    private Vector3 _tempPos;
    private Vector3 _tempScale;
    private readonly float _correctionDis = 0.25f;
    private float _speed;

    protected override void Awake()
    {
        base.Awake();
        _speed = _zombie.moveSpeed;
    }

    public void MoveZombie(Transform target)
    {
        Flip(target);
        Move(target);
    }

    private void Flip(Transform target)
    {
        _tempPos = transform.position;
        _tempScale = transform.localScale;

        if (target.position.x > _tempPos.x + _correctionDis)
        {
            _tempScale.x = -1.0f;
        }
        else if (target.position.x < _tempPos.x - _correctionDis)
        {
            _tempScale.x = 1.0f;
        }

        transform.localScale = _tempScale;
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            new Vector3(target.position.x, target.position.y, 0.0f), _speed * Time.deltaTime);
    }
}