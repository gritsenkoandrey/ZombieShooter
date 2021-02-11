using UnityEngine;


[RequireComponent(typeof(ZombieMove), (typeof(ZombieAnimation)))]
public sealed class ZombieAttack : ZombieBase
{
    [SerializeField] private Zombie _zombie = null;

    private int _damage;

    private GameObject[] _fences;
    private Transform _target;

    private readonly Collider2D[] _colliders = new Collider2D[1];
    private int _countTarget;

    private readonly float _distanceAttack = 1.5f;
    private readonly float _radiusAttack = 1.0f;

    private bool _isDistanceAttack = false;
    private bool _isCanAttack = true;

    private TimeRemaining _timeRemainingTimerAttack;
    private float _timeToTimerAttack;

    protected override void Awake()
    {
        base.Awake();

        _damage = _zombie.damage;
        _timeToTimerAttack = _zombie.attackSpeed;
        zombieHealth = GetComponentInChildren<ZombieHealth>();
        ChooseTarget();

        _timeRemainingTimerAttack = new TimeRemaining(TimerAttack, _timeToTimerAttack, true);
    }

    public override void Execute()
    {
        if (zombieHealth.Health > 0)
        {
            ZombieGoal();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(TagManager.GetTag(TypeTag.PLAYER_HEALTH))
            || target.CompareTag(TagManager.GetTag(TypeTag.PLAYER))
            || target.CompareTag(TagManager.GetTag(TypeTag.FENCE)))
        {
            _isDistanceAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.CompareTag(TagManager.GetTag(TypeTag.PLAYER_HEALTH))
            || target.CompareTag(TagManager.GetTag(TypeTag.PLAYER))
            || target.CompareTag(TagManager.GetTag(TypeTag.FENCE)))
        {
            _isDistanceAttack = false;
        }
    }

    private void ChooseTarget()
    {
        if (Data.Instance.LevelData.typeTargetZombie == TypeTargetZombie.PLAYER)
        {
            _target = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
        }

        if (Data.Instance.LevelData.typeTargetZombie == TypeTargetZombie.FENCE)
        {
            _fences = GameObject.FindGameObjectsWithTag(TagManager.GetTag(TypeTag.FENCE));
            _target = _fences[Random.Range(0, _fences.Length)].transform;
        }
    }

    private void ZombieGoal()
    {
        if (_target && Data.Instance.LevelData.typeGameGoal != TypeGameGoal.GAME_OVER)
        {
            if ((_target.position - transform.position).sqrMagnitude > _distanceAttack)
            {
                zombieMove.MoveZombie(_target);
            }
            else
            {
                AttackZombie();
            }
        }
    }

    private void AttackZombie()
    {
        if (_isDistanceAttack && _isCanAttack)
        {
            zombieAnimation.ZombieAttackAnimation();
            AudioManager.Instance.PlaySound(ClipManager.ZOMBIE_ATTACK_CLIPS[Random.Range(0, ClipManager.ZOMBIE_ATTACK_CLIPS.Length)]);
            _countTarget = Physics2D.OverlapCircleNonAlloc(transform.position, _radiusAttack, _colliders, LayerManager.ZombieAttackLayer);

            for (int i = 0; i < _countTarget; i++)
            {
                if (_colliders[i].CompareTag(TagManager.GetTag(TypeTag.PLAYER_HEALTH)))
                {
                    _colliders[i].GetComponent<PlayerHealth>().DealDamage(_damage);
                    _isCanAttack = false;
                    _timeRemainingTimerAttack.AddTimeRemaining();
                }

                if (_colliders[i].CompareTag(TagManager.GetTag(TypeTag.FENCE)))
                {
                    _colliders[i].GetComponent<FenceHealth>().DealDamage(_damage);
                    _isCanAttack = false;
                    _timeRemainingTimerAttack.AddTimeRemaining();
                }
            }
        }
    }

    private void TimerAttack()
    {
        _isCanAttack = true;
        _timeRemainingTimerAttack.RemoveTimeRemaining();
    }
}